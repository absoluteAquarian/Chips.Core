namespace Chips.Core.Specifications{
	public static unsafe class Opcodes{
		public static Opcode And_obj = new Opcode(0x00, &Opcode.Functions.And);

		public static Opcode And_var = new Opcode(0x20, &Opcode.Functions.And);
	}
}
