namespace Chips.Core.Specifications{
	internal class OpcodeTable{
		internal Opcode[] table = new Opcode[256];

		public Opcode this[int index]{
			get => table[index];
			set => table[index] = value;
		}
	}
}
