namespace Chips.Core.Specifications{
	public static unsafe class Opcodes{
		public static readonly Opcode Abs      = new(0x39, &Opcode.Functions.Abs,  "abs");
		public static readonly Opcode Acos     = new(0xA3, &Opcode.Functions.Acos, "acos");
		public static readonly Opcode Acsh     = new(0xA5, &Opcode.Functions.Acsh, "acsh");
		public static readonly Opcode Add_obj  = new(0x30, &Opcode.Functions.Add,  "add <obj>");
		public static readonly Opcode Add_var  = new(0x40, &Opcode.Functions.Add,  "add <var>");
		public static readonly Opcode And_obj  = new(0x00, &Opcode.Functions.And,  "and <obj>");
		public static readonly Opcode And_var  = new(0x20, &Opcode.Functions.And,  "and <var>");
		public static readonly Opcode Art_obj  = new(0x35, &Opcode.Functions.Art,  "art <obj>");
		public static readonly Opcode Art_var  = new(0x45, &Opcode.Functions.Art,  "art <var>");
		public static readonly Opcode Asin     = new(0xA2, &Opcode.Functions.Asin, "asin");
		public static readonly Opcode Asl      = new(0x0D, &Opcode.Functions.Asl,  "asl");
		public static readonly Opcode Asnh     = new(0x95, &Opcode.Functions.Asnh, "asnh");
		public static readonly Opcode Asr      = new(0x0E, &Opcode.Functions.Asr,  "asr");
		public static readonly Opcode Atan     = new(0xA4, &Opcode.Functions.Atan, "atan");
		public static readonly Opcode Atnh     = new(0xB5, &Opcode.Functions.Atnh, "atnh");
		public static readonly Opcode Atnt_obj = new(0xC4, &Opcode.Functions.Atnt, "atnt <obj>");
		public static readonly Opcode Atnt_var = new(0xD4, &Opcode.Functions.Atnt, "atnt <var>");

		public static readonly Opcode Bfc      = new(0x11, &Opcode.Functions.Br,   "bfc <label>");
		public static readonly Opcode Bfn      = new(0x13, &Opcode.Functions.Br,   "bfn <label>");
		public static readonly Opcode Bfo      = new(0x15, &Opcode.Functions.Br,   "bfo <label>");
		public static readonly Opcode Bfp      = new(0x84, &Opcode.Functions.Br,   "bfp <label>");
		public static readonly Opcode Bfr      = new(0x17, &Opcode.Functions.Br,   "bfr <label>");
		public static readonly Opcode Bfz      = new(0x19, &Opcode.Functions.Br,   "bfz <label>");
		public static readonly Opcode Blg      = new(0x38, &Opcode.Functions.Blg,  "blg");
		public static readonly Opcode Br       = new(0x1A, &Opcode.Functions.Br,   "br <label>");
		public static readonly Opcode Brf_obj  = new(0x7C, &Opcode.Functions.Br,   "brf <obj>, <label>");
		public static readonly Opcode Brf_var  = new(0x7D, &Opcode.Functions.Br,   "brf <var>, <label>");
		public static readonly Opcode Brt_obj  = new(0x7A, &Opcode.Functions.Br,   "brt <obj>, <label>");
		public static readonly Opcode Brt_var  = new(0x7B, &Opcode.Functions.Br,   "brt <var>, <label>");
		public static readonly Opcode Btc      = new(0x10, &Opcode.Functions.Br,   "btc <label>");
		public static readonly Opcode Btn      = new(0x12, &Opcode.Functions.Br,   "btn <label>");
		public static readonly Opcode Bto      = new(0x14, &Opcode.Functions.Br,   "bto <label>");
		public static readonly Opcode Btp      = new(0x74, &Opcode.Functions.Br,   "btp <label>");
		public static readonly Opcode Btr      = new(0x16, &Opcode.Functions.Br,   "btr <label>");
		public static readonly Opcode Btz      = new(0x18, &Opcode.Functions.Br,   "btz <label>");
		public static readonly Opcode Bin      = new(0x67, &Opcode.Functions.Bin,  "bin");
		public static readonly Opcode Binz     = new(0x68, &Opcode.Functions.Binz, "binz");
		public static readonly Opcode Bit_obj  = new(0x69, &Opcode.Functions.Bit,  "bit <obj>");
		public static readonly Opcode Bit_var  = new(0x79, &Opcode.Functions.Bit,  "bit <var>");
		public static readonly Opcode Bits     = new(0x6A, &Opcode.Functions.Bits, "bits");
	}
}
