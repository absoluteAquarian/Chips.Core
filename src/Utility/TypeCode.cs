using System.Numerics;

namespace Chips.Core.Utility {
	public enum TypeCode {
		Null = 255,
		/// <summary>
		/// i32 - signed 32bit integer
		/// </summary>
		Int32 = 0,
		/// <summary>
		/// i8 - signed 8bit integer
		/// </summary>
		Int8,
		/// <summary>
		/// i16 - signed 16bit integer
		/// </summary>
		Int16,
		/// <summary>
		/// i64 - signed 64bit integer
		/// </summary>
		Int64,
		/// <summary>
		/// u32 - unsigned 32bit integer
		/// </summary>
		Uint32,
		/// <summary>
		/// u8 - unsigned 8bit integer
		/// </summary>
		Uint8,
		/// <summary>
		/// u16 - unsigned 16bit integer
		/// </summary>
		Uint16,
		/// <summary>
		/// u64 - unsigned 64bit integer
		/// </summary>
		Uint64,
		/// <summary>
		/// iex - <seealso cref="BigInteger"/>
		/// </summary>
		BigInt,
		/// <summary>
		/// f32 - 32bit floating-point value
		/// </summary>
		Float32,
		/// <summary>
		/// f64 - 64bit floating-point value
		/// </summary>
		Float64,
		/// <summary>
		/// f128 - 128bit floating-point value
		/// </summary>
		Float128,
		/// <summary>
		/// obj - object type
		/// </summary>
		Obj,
		/// <summary>
		/// char - 2-byte character
		/// </summary>
		Char,
		/// <summary>
		/// str - string value
		/// </summary>
		Str,
		/// <summary>
		/// ^u32 - indexer
		/// </summary>
		Indexer,
		/// <summary>
		/// ~arr:&lt;type&gt; - array
		/// </summary>
		Array,
		/// <summary>
		/// ~range - range of integers
		/// </summary>
		Range,
		/// <summary>
		/// ~list - dynamic-sized collection of objects
		/// </summary>
		List,
		/// <summary>
		/// ~time - <seealso cref="TimeSpan"/>
		/// </summary>
		Time,
		/// <summary>
		/// ~set - arithmetic set of numbers
		/// </summary>
		Set,
		/// <summary>
		/// ~date - <seealso cref="DateTime"/>
		/// </summary>
		Date,
		/// <summary>
		/// ~regex - <seealso cref="System.Text.RegularExpressions.Regex"/>
		/// </summary>
		Regex,
		/// <summary>
		/// bool - boolean
		/// </summary>
		Bool,
		/// <summary>
		/// ~range - <seealso cref="Random"/>
		/// </summary>
		Rand,
		/// <summary>
		/// ~cplx - <seealso cref="System.Numerics.Complex"/>
		/// </summary>
		Complex,
		/// <summary>
		/// ~ud:&lt;TYPE_NAME&gt; - user-defined types in Chips
		/// </summary>
		UserDefined,
		/// <summary>
		/// f16 - 16bit floating-point value
		/// </summary>
		Float16
	}
}
