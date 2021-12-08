namespace Chips.Core.Specifications{
	public static unsafe class Opcodes{
		public static readonly Opcode Abs     = new(0x39, &Opcode.Functions.Abs,  "abs");
		public static readonly Opcode Acos    = new(0xA3, &Opcode.Functions.Acos, "acos");
		public static readonly Opcode Acsh    = new(0xA5, &Opcode.Functions.Acsh, "acsh");
		public static readonly Opcode Add_obj = new(0x30, &Opcode.Functions.Add,  "add <obj>");
		public static readonly Opcode Add_var = new(0x40, &Opcode.Functions.Add,  "add <var>");
		public static readonly Opcode And_obj = new(0x00, &Opcode.Functions.And,  "and <obj>");
		public static readonly Opcode And_var = new(0x20, &Opcode.Functions.And,  "and <var>");
	}
}
