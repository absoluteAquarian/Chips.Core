using Chips.Core.Meta;
using Chips.Core.Types;
using Chips.Core.Utility;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Chips.Core.Specifications{
	public unsafe partial class Opcode{
		public struct FunctionContext{
			internal object[] args;
			
			internal string? sourceFile;
			internal int sourceLine;

			public static readonly FunctionContext NoContext = new();

			public FunctionContext(){
				args = Array.Empty<object>();
				sourceFile = null;
				sourceLine = -1;
			}

			public FunctionContext(string sourceFile, int sourceLine, params object[] args){
				this.sourceFile = sourceFile;
				this.sourceLine = sourceLine;
				this.args = args;
			}
		}

		public readonly byte code;
		public readonly string descriptor;

		public bool IsParent => table is not null;

		public readonly OpcodeTable? table;
		internal Opcode? parent;

		internal readonly delegate*<FunctionContext, void> func;

		public Opcode(byte code, delegate*<FunctionContext, void> func, string descriptor, params Opcode[] derivedCodes){
			this.code = code;
			this.descriptor = descriptor;
			this.func = func;
			
			if(derivedCodes is not null && derivedCodes.Length > 0){
				table = new();

				foreach(var subCode in derivedCodes){
					table.table[subCode.code] = subCode;
					subCode.parent = this;
				}
			}
		}

		public void Invoke(FunctionContext context){
			if(IsParent)
				throw new InvalidOperationException("Internal Chips Error: Attempted to invoke an opcode type with sub-types defined"
					+ ExceptionHelper.GetContextString(context));

			Register.globalContext = context;
			func(context);
		}

		internal static void CheckZeroFlag_RegisterA(bool checkIntegers = false, bool checkFloats = false, bool checkCollections = false, bool checkStrings = false)
			=> CheckZeroFlag(Metadata.Registers.A.Data, checkIntegers, checkFloats, checkCollections, checkStrings);

		internal static void CheckZeroFlag_RegisterS(){
			if(string.IsNullOrEmpty(Metadata.Registers.S.Data as string))
				Metadata.Flags.Zero = true;
		}

		internal static void CheckZeroFlag_RegisterX(){
			var obj = Metadata.Registers.X.Data;
			if((ValueConverter.AsUnsignedInteger(obj) is ulong ul && ul == 0) || (ValueConverter.AsSignedInteger(obj) is long l && l == 0))
				Metadata.Flags.Zero = true;
		}

		internal static void CheckZeroFlag_RegisterY(){
			var obj = Metadata.Registers.Y.Data;
			if((ValueConverter.AsUnsignedInteger(obj) is ulong ul && ul == 0) || (ValueConverter.AsSignedInteger(obj) is long l && l == 0))
				Metadata.Flags.Zero = true;
		}

		internal static void CheckZeroFlag_RegisterSP(){
			if((int)Metadata.Registers.SP.Data! == 0)
				Metadata.Flags.Zero = true;
		}

		internal static void CheckZeroFlag(object? obj, bool checkIntegers = false, bool checkFloats = false, bool checkCollections = false, bool checkStrings = false){
			if(obj is null){
				Metadata.Flags.Zero = true;
				return;
			}

			var type = obj.GetType();

			bool zeroFlagSuccess_Integer = checkIntegers && type.IsPrimitive
				&& ((obj is char c && c == 0)
				|| (obj is bool b && b)
				|| (obj is DateTime date && date == default)
				|| (obj is TimeSpan time && time == default)
				|| (ValueConverter.AsUnsignedInteger(obj) is ulong ul && ul == 0)
				|| (ValueConverter.AsSignedInteger(obj) is long l && l == 0));
			bool zeroFlagSucess_Float = checkFloats
				&& ((obj is Half h && h == (Half)0f)
				|| (obj is Complex cm && cm == Complex.Zero)
				|| (type.IsPrimitive && ValueConverter.AsFloatingPoint(obj) is double d && d == 0d));
			bool zeroFlagSuccess_Collections = checkCollections
				&& ((obj is Array array && array.Length == 0)
				|| (obj is List list && list.Count == 0)
				|| (obj is ArithmeticSet set && set.IsEmptySet));
			bool zeroFlagSuccess_String = checkStrings && obj is string str && str == "";

			if(zeroFlagSuccess_Integer || zeroFlagSucess_Float || zeroFlagSuccess_Collections || zeroFlagSuccess_String)
				Metadata.Flags.Zero = true;
		}

		internal static bool ValueIsValidForIOStreamHandle(object? obj, out int handle){
			handle = -1;

			if(ValueConverter.AsSignedInteger(obj) is long l && l >= 0 && l < Sandbox.IO_HANDLES)
				handle = (int)l;
			else if(ValueConverter.AsUnsignedInteger(obj) is ulong ul && ul < Sandbox.IO_HANDLES)
				handle = (int)ul;

			return handle > -1;
		}
	}
}
