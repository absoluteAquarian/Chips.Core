using Chips.Core.Meta;
using Chips.Core.Types;
using Chips.Core.Types.UserDefined;
using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Chips.Core.Utility{
	public static class TypeTracking{
		private static readonly Dictionary<Type, object> cachedObjects = new();
		private static readonly Dictionary<Type, ChipsGeneratedAttribute?> cachedGeneratedAttribute = new();
		private static readonly Dictionary<Type, Type> cachedArrayTypes = new();
		private static readonly Dictionary<string, Type> cachedNameToTypes = new();

		internal delegate bool ParseValue(string? str, out object? result);
		private delegate bool ParseValue<T>(string? str, out T result);

		private static ParseValue CreateParseValueDelegate<T>(ParseValue<T> func)
			=> (string? str, out object? result) => {
				bool success = func(str, out T typedResult);
				result = typedResult;
				return success;
			};

		internal static readonly Dictionary<string, ParseValue> cachedParseFuncs = new(){
			["i32"] = CreateParseValueDelegate<int>(int.TryParse),
			["i8"] = CreateParseValueDelegate<sbyte>(sbyte.TryParse),
			["i16"] = CreateParseValueDelegate<short>(short.TryParse),
			["i64"] = CreateParseValueDelegate<long>(long.TryParse),
			["u32"] = CreateParseValueDelegate<uint>(uint.TryParse),
			["u8"] = CreateParseValueDelegate<byte>(byte.TryParse),
			["u16"] = CreateParseValueDelegate<ushort>(ushort.TryParse),
			["u64"] = CreateParseValueDelegate<ulong>(ulong.TryParse),
			["iex"] = CreateParseValueDelegate<BigInteger>(BigInteger.TryParse),
			["f32"] = CreateParseValueDelegate<float>(float.TryParse),
			["f64"] = CreateParseValueDelegate<double>(double.TryParse),
			["f128"] = CreateParseValueDelegate<decimal>(decimal.TryParse),
			["char"] = CreateParseValueDelegate<char>(char.TryParse),
			["~index"] = CreateParseValueDelegate<Indexer>(Indexer.TryParse),
			["~range"] = CreateParseValueDelegate<Types.Range>(Types.Range.TryParse),
			["bool"] = CreateParseValueDelegate<bool>(bool.TryParse),
			["~cplx"] = (string? str, out object? result) => {
				if(str is null){
					result = Complex.Zero;
					return false;
				}

				//Real only
				if(double.TryParse(str, out double d)){
					result = new Complex(d, 0);
					return true;
				}

				ReadOnlySpan<char> span = str.AsSpan(), a, b;

				//Imaginary only
				if(span[^1] == 'i' && double.TryParse(span[..^1], out d)){
					result = new Complex(0, d);
					return true;
				}

				int opIndex;
				if((opIndex = span.LastIndexOf('+')) > 0 || (opIndex = span.LastIndexOf('-')) > 0){
					//Both real and imaginary
					a = span[..opIndex];
					b = span[opIndex..];

					if(double.TryParse(a.TrimEnd(), out double real) && b[^1] == 'i' && double.TryParse(b[..^1].TrimStart(), out double imag)){
						result = new Complex(real, imag);
						return true;
					}
				}

				result = null;
				return false;
			},
			["f16"] = CreateParseValueDelegate<Half>(Half.TryParse)
		};

		public static bool IsInteger(object? arg)
			=> arg is sbyte or short or int or long or byte or ushort or uint or ulong or BigInteger;

		public static bool IsString(object? arg)
			=> arg is string;

		public static bool IsFloatingPoint(object? arg)
			=> arg is float or double or decimal or Half;

		public static string? GetChipsType(object? o, bool throwOnNotFound = true)
			=> o switch{
				int _ => "i32",
				sbyte _ => "i8",
				short _ => "i16",
				long _ => "i64",
				uint _ => "u32",
				byte _ => "u8",
				ushort _ => "u16",
				ulong _ => "u64",
				BigInteger _ => "iex",
				float _ => "f32",
				double _ => "f64",
				decimal _ => "f128",
				char _ => "char",
				string _ => "str",
				Indexer _ => "~index",
				Array _ => $"~arr:{GetChipsType(o.GetType().GetElementType()!, throwOnNotFound)}",
				Types.Range _ => "~range",
				List _ => "~list",
				TimeSpan _ => "~time",
				ArithmeticSet _ => "~set",
				DateTime _ => "~date",
				Types.Regex _ => "~regex",
				bool _ => "bool",
				Random _ => "~rand",
				Complex _ => "~cplx",
				Half _ => "f16",
				null => "null",
				_ when o.GetType() == typeof(object) => "obj",
				_ when o is IChipsStruct => $"~ud:{o.GetType().Name}",
				_ => !throwOnNotFound ? null : throw new ArgumentException($"Type \"{o.GetType().FullName}\" does not have a defined Chips type code")
			};

		public static Type? GetCSharpType(string chipsType)
			=> chipsType switch{
				"i32" => typeof(int),
				"i8" => typeof(sbyte),
				"i16" => typeof(short),
				"i64" => typeof(long),
				"u32" => typeof(uint),
				"u8" => typeof(byte),
				"u16" => typeof(ushort),
				"u64" => typeof(ulong),
				"iex" => typeof(BigInteger),
				"f32" => typeof(float),
				"f64" => typeof(double),
				"f128" => typeof(decimal),
				"obj" => typeof(object),
				"char" => typeof(char),
				"str" => typeof(string),
				"~index" => typeof(Indexer),
				"~range" => typeof(Types.Range),
				"~list" => typeof(List),
				"~time" => typeof(TimeSpan),
				"~date" => typeof(DateTime),
				"~regex" => typeof(Types.Regex),
				"bool" => typeof(bool),
				"~rand" => typeof(Random),
				"~cplx" => typeof(Complex),
				"f16" => typeof(Half),
				"null" => null,
				_ when chipsType.StartsWith("~arr:") => GetCSharpType(chipsType[5..]) is Type type
					? GetArrayType(type)
					: throw new ArgumentException($"Type \"{chipsType[5..]}\" is not a valid member type for arrays"),
				_ when chipsType.StartsWith("~ud:") => GetTypeFromAnyAssembly(chipsType[4..], throwOnNotFound: false)
					?? throw new ArgumentException($"Type \"{chipsType[4..]}\" does not exist"),
				_ => throw new ArgumentException($"Type \"{chipsType}\" does not exist in Chips and is not a user-defined type")
			};

		public static Type? GetCSharpType(TypeCode code)
			=> code switch{
				TypeCode.Null => null,
				TypeCode.Int32 => typeof(int),
				TypeCode.Int8 => typeof(sbyte),
				TypeCode.Int16 => typeof(short),
				TypeCode.Int64 => typeof(long),
				TypeCode.Uint32 => typeof(uint),
				TypeCode.Uint8 => typeof(byte),
				TypeCode.Uint16 => typeof(ushort),
				TypeCode.Uint64 => typeof(ulong),
				TypeCode.BigInt => typeof(BigInteger),
				TypeCode.Float32 => typeof(float),
				TypeCode.Float64 => typeof(double),
				TypeCode.Float128 => typeof(decimal),
				TypeCode.Obj => typeof(object),
				TypeCode.Char => typeof(char),
				TypeCode.Str => typeof(string),
				TypeCode.Indexer => typeof(Indexer),
				TypeCode.Array => null,  //Shouldn't be used directly
				TypeCode.Range => typeof(Types.Range),
				TypeCode.List => typeof(List),
				TypeCode.Time => typeof(TimeSpan),
				TypeCode.Set => typeof(ArithmeticSet),
				TypeCode.Date => typeof(DateTime),
				TypeCode.Regex => typeof(Types.Regex),
				TypeCode.Bool => typeof(bool),
				TypeCode.Rand => typeof(Random),
				TypeCode.Complex => typeof(Complex),
				TypeCode.UserDefined => null,
				TypeCode.Float16 => typeof(Half),
				_ => throw new ArgumentException("Unknown type code: " + code)
			};

		public static string? GetChipsType(Type t, bool throwOnNotFound = true){
			if(!cachedObjects.TryGetValue(t, out object? obj))
				cachedObjects.Add(t, obj = Activator.CreateInstance(t)!);

			return GetChipsType(obj, throwOnNotFound);
		}

		public static string? GetChipsType<T>(bool throwOnNotFound = true) where T : new(){
			Type t = typeof(T);
			if(!cachedObjects.TryGetValue(t, out object? obj))
				cachedObjects.Add(t, obj = new T());

			return GetChipsType(obj, throwOnNotFound);
		}

		public static TypeCode GetTypeCode(object? o)
			=> o switch{
				int _ => TypeCode.Int32,
				sbyte _ => TypeCode.Int8,
				short _ => TypeCode.Int16,
				long _ => TypeCode.Int64,
				uint _ => TypeCode.Uint32,
				byte _ => TypeCode.Uint8,
				ushort _ => TypeCode.Uint16,
				ulong _ => TypeCode.Uint64,
				BigInteger _ => TypeCode.BigInt,
				float _ => TypeCode.Float32,
				double _ => TypeCode.Float64,
				decimal _ => TypeCode.Float128,
				char _ => TypeCode.Char,
				string _ => TypeCode.Str,
				Indexer _ => TypeCode.Indexer,
				Array _ => TypeCode.Array,
				Types.Range _ => TypeCode.Range,
				List _ => TypeCode.List,
				TimeSpan _ => TypeCode.Time,
				ArithmeticSet _ => TypeCode.Set,
				DateTime _ => TypeCode.Date,
				Types.Regex _ => TypeCode.Regex,
				bool _ => TypeCode.Bool,
				Random _ => TypeCode.Rand,
				Complex _ => TypeCode.Complex,
				Half _ => TypeCode.Float16,
				null => TypeCode.Null,
				_ when o.GetType() == typeof(object) => TypeCode.Obj,
				_ when o is IChipsStruct => TypeCode.UserDefined,
				_ => throw new ArgumentException($"Type \"{o.GetType().FullName}\" does not have a defined Chips type code")
			};

		public static TypeCode GetTypeCode(Type t){
			if(!cachedObjects.TryGetValue(t, out object? obj))
				cachedObjects.Add(t, obj = Activator.CreateInstance(t)!);

			return GetTypeCode(obj);
		}

		public static TypeCode GetTypeCode<T>() where T : new(){
			Type t = typeof(T);
			if(!cachedObjects.TryGetValue(t, out object? obj))
				cachedObjects.Add(t, obj = new T());

			return GetTypeCode(obj);
		}

		private static Type GetArrayType(Type elementType){
			if(!cachedArrayTypes.TryGetValue(elementType, out Type? type))
				cachedArrayTypes.Add(elementType, type = Array.CreateInstance(elementType, 0).GetType());

			return type;
		}

		private static ChipsGeneratedAttribute? GetChipsGeneratedAttribute(this object o){
			Type t = o.GetType();
			if(!cachedGeneratedAttribute.TryGetValue(t, out ChipsGeneratedAttribute? attr))
				cachedGeneratedAttribute.Add(t, attr = Attribute.GetCustomAttribute(t, typeof(ChipsGeneratedAttribute)) as ChipsGeneratedAttribute);

			return attr;
		}

		internal static int GetSizeFromNumericType(Type t){
			if(t == typeof(sbyte) || t == typeof(byte))
				return 1;
			if(t == typeof(short) || t == typeof(ushort) || t == typeof(Half))
				return 2;
			if(t == typeof(int) || t == typeof(uint) || t == typeof(float))
				return 4;
			if(t == typeof(long) || t == typeof(ulong) || t == typeof(double))
				return 8;
			if(t == typeof(decimal) || t == typeof(Complex))
				return 16;
			if(t == typeof(BigInteger))
				return 32;  //Just need to make sure it's "larger" than ulong and long

			throw new Exception($"Internal Chips Exception -- Invalid Type for {nameof(TypeTracking)}.{nameof(GetSizeFromNumericType)}: {t.FullName}");
		}

		internal static Type? GetTypeFromAnyAssembly(string name, bool throwOnNotFound = true){
			Type? search = null;
			string? generatedKey = null;
			foreach(var asm in AppDomain.CurrentDomain.GetAssemblies()){
				if(asm.IsDynamic)
					continue;

				search = GetType(name, asm, out generatedKey, throwOnNotFound: false);
				if(search is not null)
					break;
			}

			if(throwOnNotFound && search is null)
				throw new ArgumentException($"Type \"{generatedKey ?? name}\" could not be found");

			return search;
		}

		internal static Type? GetType(string name, Assembly? assembly, out string generatedKey, bool throwOnNotFound = true){
			string? asm = assembly?.GetName().Name;
			generatedKey = name = (asm is null ? "" : asm + "::") + name;

			if(!cachedNameToTypes.TryGetValue(name, out Type? type)){
				type = assembly?.GetType(name) ?? Type.GetType(name);

				if(type is not null)
					cachedNameToTypes.Add(name, type!);

				if(throwOnNotFound && type is null)
					throw new ArgumentException($"Type \"{name}\" could not be found");
			}

			return type;
		}
	}
}
