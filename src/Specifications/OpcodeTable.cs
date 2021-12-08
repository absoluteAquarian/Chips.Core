namespace Chips.Core.Specifications{
	internal class OpcodeTable{
		internal Opcode[] table = new Opcode[256];

		public Opcode this[int index]{
			get{
				var op = table[index];
				if(op is null)
					throw new Exception($"Unknown opcode (0x{index:X2})");
				return op;
			}
			set => table[index] = value;
		}

		public Opcode this[Opcode opcode]{
			get => table[opcode.code];
			internal set => table[value.code] = value;
		}
	}
}
