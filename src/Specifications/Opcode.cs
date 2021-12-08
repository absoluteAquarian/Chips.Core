using Chips.Core.Meta;
using Chips.Core.Types;
using Chips.Core.Utility;

namespace Chips.Core.Specifications{
	public unsafe partial class Opcode{
		public struct FunctionContext{
			internal object[] args = Array.Empty<object>();
			
			internal string? sourceFile = null;
			internal int sourceLine = -1;

			public FunctionContext(string sourceFile, int sourceLine, params object[] args){
				this.sourceFile = sourceFile;
				this.sourceLine = sourceLine;
				this.args = args;
			}
		}

		public readonly byte code;
		public readonly string descriptor;

		public bool IsParent => table is not null;

		internal OpcodeTable? table;
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
				throw new InvalidOperationException("Internal Chips Error: Attempted to invoke an opcode type with sub-types defined");

			Register.globalContext = context;
			func(context);
		}

		internal static void CheckZeroFlag(object? obj, bool checkIntegers = false, bool checkFloats = false, bool checkCollections = false, bool checkStrings = false){
			if(obj is null){
				Metadata.Flags.Zero = true;
				return;
			}

			var type = obj.GetType();

			bool zeroFlagSuccess_Integer = checkIntegers && type.IsPrimitive && ((ValueConverter.AsUnsignedInteger(obj) is ulong ul && ul == 0) || (ValueConverter.AsSignedInteger(obj) is long l && l == 0) || (obj is char c && c == 0));
			bool zeroFlagSucess_Float = checkFloats && type.IsPrimitive && ValueConverter.AsFloatingPoint(obj) is double d && d == 0d;
			bool zeroFlagSuccess_Collections = checkCollections && ((obj is Array array && array.Length == 0) || (obj is List list && list.Count == 0) || (obj is ArithmeticSet set && set.IsEmptySet));
			bool zeroFlagSuccess_String = checkStrings && obj is string str && str == "";

			if(zeroFlagSuccess_Integer || zeroFlagSucess_Float || zeroFlagSuccess_Collections || zeroFlagSuccess_String)
				Metadata.Flags.Zero = true;
		}
	}
}
