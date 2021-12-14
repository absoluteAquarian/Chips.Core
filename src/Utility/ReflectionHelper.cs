using System.Reflection;
using System.Reflection.Emit;

namespace Chips.Core.Utility{
	internal static class ReflectionHelper<T>{
		public class MethodPackage{
			private readonly string getMethod;
			private readonly string setMethod;

			public MethodPackage(string field){
				CreateGetAccessor(field, out getMethod);
				CreateSetAccessor(field, out setMethod);
			}

			public object? this[T arg]{
				get => InvokeGetterFunction(getMethod, arg);
				set => InvokeSetterFunction(setMethod, arg, value);
			}
		}

		private static readonly Dictionary<string, Func<T, object?>> getterFuncs = new();
		private static readonly Dictionary<string, Action<T, object?>> setterFuncs = new();

		public static object? InvokeGetterFunction(string name, T arg)
			=> getterFuncs.TryGetValue(name, out var func) ? func(arg) : throw new Exception($"Dynamic getter method \"{name}\" has not been defined");

		public static void InvokeSetterFunction(string name, T arg, object? obj){
			if(setterFuncs.TryGetValue(name, out var func))
				func(arg, obj);
			else
				throw new Exception($"Dynamic setter method \"{name}\" has not been defined");
		}

		public static void CreateGetAccessor(string field, out string name){
			name = "get_" + field;
			if(getterFuncs.ContainsKey(name))
				throw new Exception($"Dynamic getter method \"{name}\" has already been defined");

			FieldInfo? fieldInfo = typeof(T).GetField(field, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
			if(fieldInfo is null)
				throw new Exception($"Field \"{typeof(T).FullName}::{field}\" could not be found");

			var method = new DynamicMethod(name, typeof(object), new[]{ typeof(T) }, typeof(T).Module, skipVisibility: true);
			var il = method.GetILGenerator();

			//return arg0.field;
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldfld, fieldInfo);

			if(fieldInfo.FieldType.IsValueType)
				il.Emit(OpCodes.Box, fieldInfo.FieldType);

			il.Emit(OpCodes.Ret);

			getterFuncs[name] = (Func<T, object?>)method.CreateDelegate(typeof(Func<T, object?>));
		}

		public static void CreateSetAccessor(string field, out string name){
			name = "set_" + field;
			if(setterFuncs.ContainsKey(name))
				throw new Exception($"Dynamic setter method \"{name}\" has already been defined");

			FieldInfo? fieldInfo = typeof(T).GetField(field, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
			if(fieldInfo is null)
				throw new Exception($"Field \"{typeof(T).FullName}::{field}\" could not be found");

			//arg0.field = arg1;
			var method = new DynamicMethod(name, null, new[]{ typeof(T), typeof(object) }, typeof(T).Module, skipVisibility: true);
			var il = method.GetILGenerator();

			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldarg_1);

			if(fieldInfo.FieldType.IsValueType)
				il.Emit(OpCodes.Unbox_Any, fieldInfo.FieldType);
			else
				il.Emit(OpCodes.Castclass, fieldInfo.FieldType);

			il.Emit(OpCodes.Stfld, fieldInfo);
			il.Emit(OpCodes.Ret);

			setterFuncs[name] = (Action<T, object?>)method.CreateDelegate(typeof(Action<T, object?>));
		}

		
	}

	internal static class ReflectionHelper{
		private static readonly Dictionary<string, ConstructorInfo> constructors = new();

		public static ConstructorInfo GetConstructor(string accessKey, Type srcType, Type[] argTypes){
			if(!constructors.TryGetValue(accessKey, out var constructor)){
				constructors.Add(accessKey, constructor = srcType.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, argTypes)
					?? throw new ArgumentException($"Could not find constructor for type <{TypeTracking.GetChipsType(srcType, throwOnNotFound: false)}>"));
			}

			return constructor;
		}
	}
}
