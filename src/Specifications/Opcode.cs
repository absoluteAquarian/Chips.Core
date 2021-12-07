namespace Chips.Core.Specifications{
	public unsafe partial class Opcode{
		public struct FunctionContext{
			internal object[] args;
			
			internal string sourceFile;
			internal int sourceLine;

			public FunctionContext(string sourceFile, int sourceLine, params object[] args){
				this.sourceFile = sourceFile;
				this.sourceLine = sourceLine;
				this.args = args;
			}
		}

		public readonly byte code;

		public bool IsParent => table is not null;

		internal readonly OpcodeTable? table;

		internal readonly delegate*<FunctionContext, void> func;

		public Opcode(byte code, delegate*<FunctionContext, void> func, params Opcode[] derivedCodes){
			this.code = code;
			this.func = func;
			
			if(derivedCodes is not null && derivedCodes.Length > 0){
				table = new();

				foreach(var subCode in derivedCodes)
					table.table[subCode.code] = subCode;
			}
		}
	}
}
