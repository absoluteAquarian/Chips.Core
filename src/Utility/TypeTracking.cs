﻿using Chips.Core.Meta;
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

		public static bool IsInteger(object? arg)
			=> arg is sbyte or short or int or long or byte or ushort or uint or ulong or BigInteger;

		public static bool IsString(object? arg)
			=> arg is string;

		public static bool IsFloatingPoint(object? arg)
			=> arg is float or double or decimal;

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
				Regex _ => "~regex",
				bool _ => "bool",
				Random _ => "~rand",
				Complex _ => "~cplx",
				Half _ => "f16",
				null => "null",
				_ when o.GetType() == typeof(object) => "obj",
				_ when o.GetChipsGeneratedAttribute() is not null => $"~ud:{o.GetType().Name}",
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
				"~regex" => typeof(Regex),
				"bool" => typeof(bool),
				"~rand" => typeof(Random),
				"~cplx" => typeof(Complex),
				"f16" => typeof(Half),
				"null" => null,
				_ when chipsType.StartsWith("~arr:") => GetCSharpType(chipsType[5..]) is Type type
					? GetArrayType(type)
					: throw new ArgumentException($"Type \"{chipsType[5..]}\" is not a valid member type for arrays"),
				_ when chipsType.StartsWith("~ud:") => Assembly.GetEntryAssembly()?.GetType(chipsType[4..], throwOnError: false)
					?? throw new ArgumentException($"Type \"{chipsType[4..]}\" does not exist in the program's assembly"),
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
				TypeCode.Regex => typeof(Regex),
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
				Regex _ => TypeCode.Regex,
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

			throw new Exception($"Internal Chips Exception -- Invalid Type for {nameof(TypeTracking)}.{nameof(GetSizeFromNumericType)}: {t.FullName}");
		}

		internal static Type GetType(string name, Assembly? assembly){
			string? asm = assembly?.GetName().Name;
			name = (asm is null ? "" : asm + "::") + name;

			if(!cachedNameToTypes.TryGetValue(name, out Type? type))
				cachedNameToTypes.Add(name, assembly?.GetType(name) ?? Type.GetType(name) ?? throw new ArgumentException($"Type \"{name}\" could not be found"));

			return type!;
		}
	}
}
