namespace Chips.Core.Specifications{
	public static unsafe class Opcodes{
		public static readonly Opcode Abs      = new(0x39, &Opcode.Functions.Abs,              "abs"                       );
		public static readonly Opcode Acos     = new(0xA3, &Opcode.Functions.Acos,             "acos"                      );
		public static readonly Opcode Acsh     = new(0xA5, &Opcode.Functions.Acsh,             "acsh"                      );
		public static readonly Opcode Add_obj  = new(0x30, &Opcode.Functions.Add,              "add <obj>"                 );
		public static readonly Opcode Add_var  = new(0x40, &Opcode.Functions.Add,              "add <var>"                 );
		public static readonly Opcode And_obj  = new(0x00, &Opcode.Functions.And,              "and <obj>"                 );
		public static readonly Opcode And_var  = new(0x20, &Opcode.Functions.And,              "and <var>"                 );
		public static readonly Opcode Art_obj  = new(0x35, &Opcode.Functions.Art,              "art <obj>"                 );
		public static readonly Opcode Art_var  = new(0x45, &Opcode.Functions.Art,              "art <var>"                 );
		public static readonly Opcode Asin     = new(0xA2, &Opcode.Functions.Asin,             "asin"                      );
		public static readonly Opcode Asl      = new(0x0D, &Opcode.Functions.Asl,              "asl"                       );
		public static readonly Opcode Asnh     = new(0x95, &Opcode.Functions.Asnh,             "asnh"                      );
		public static readonly Opcode Asr      = new(0x0E, &Opcode.Functions.Asr,              "asr"                       );
		public static readonly Opcode Atan     = new(0xA4, &Opcode.Functions.Atan,             "atan"                      );
		public static readonly Opcode Atnh     = new(0xB5, &Opcode.Functions.Atnh,             "atnh"                      );
		public static readonly Opcode Atnt_obj = new(0xC4, &Opcode.Functions.Atnt,             "atnt <obj>"                );
		public static readonly Opcode Atnt_var = new(0xD4, &Opcode.Functions.Atnt,             "atnt <var>"                );

		public static readonly Opcode Bfc      = new(0x11, &Opcode.Functions.Br,               "bfc <label>"               );
		public static readonly Opcode Bfn      = new(0x13, &Opcode.Functions.Br,               "bfn <label>"               );
		public static readonly Opcode Bfo      = new(0x15, &Opcode.Functions.Br,               "bfo <label>"               );
		public static readonly Opcode Bfp      = new(0x84, &Opcode.Functions.Br,               "bfp <label>"               );
		public static readonly Opcode Bfr      = new(0x17, &Opcode.Functions.Br,               "bfr <label>"               );
		public static readonly Opcode Bfz      = new(0x19, &Opcode.Functions.Br,               "bfz <label>"               );
		public static readonly Opcode Blg      = new(0x38, &Opcode.Functions.Blg,              "blg"                       );
		public static readonly Opcode Br       = new(0x1A, &Opcode.Functions.Br,               "br <label>"                );
		public static readonly Opcode Brf_obj  = new(0x7C, &Opcode.Functions.Br,               "brf <obj>, <label>"        );
		public static readonly Opcode Brf_var  = new(0x7D, &Opcode.Functions.Br,               "brf <var>, <label>"        );
		public static readonly Opcode Brt_obj  = new(0x7A, &Opcode.Functions.Br,               "brt <obj>, <label>"        );
		public static readonly Opcode Brt_var  = new(0x7B, &Opcode.Functions.Br,               "brt <var>, <label>"        );
		public static readonly Opcode Btc      = new(0x10, &Opcode.Functions.Br,               "btc <label>"               );
		public static readonly Opcode Btn      = new(0x12, &Opcode.Functions.Br,               "btn <label>"               );
		public static readonly Opcode Bto      = new(0x14, &Opcode.Functions.Br,               "bto <label>"               );
		public static readonly Opcode Btp      = new(0x74, &Opcode.Functions.Br,               "btp <label>"               );
		public static readonly Opcode Btr      = new(0x16, &Opcode.Functions.Br,               "btr <label>"               );
		public static readonly Opcode Btz      = new(0x18, &Opcode.Functions.Br,               "btz <label>"               );
		public static readonly Opcode Bin      = new(0x67, &Opcode.Functions.Bin,              "bin"                       );
		public static readonly Opcode Binz     = new(0x68, &Opcode.Functions.Binz,             "binz"                      );
		public static readonly Opcode Bit_obj  = new(0x69, &Opcode.Functions.Bit,              "bit <obj>"                 );
		public static readonly Opcode Bit_var  = new(0x79, &Opcode.Functions.Bit,              "bit <var>"                 );
		public static readonly Opcode Bits     = new(0x6A, &Opcode.Functions.Bits,             "bits"                      );

		public static readonly Opcode Call     = new(0x1B, &Opcode.Functions.Call,             "call <func>"               );
		public static readonly Opcode Caps     = new(0xF7, &Opcode.Functions.Caps,             "caps"                      );
		public static readonly Opcode Cast     = new(0x63, &Opcode.Functions.Cast,             "cast <type>"               );
		public static readonly Opcode Cclb     = new(0xF5, &Opcode.Functions.Cclb,             "cclb"                      );
		public static readonly Opcode Cclf     = new(0xF6, &Opcode.Functions.Cclf,             "cclf"                      );
		public static readonly Opcode Ceil     = new(0xA1, &Opcode.Functions.Ceil,             "ceil"                      );
		public static readonly Opcode Ceq_obj  = new(0x05, &Opcode.Functions.Ceq,              "ceq <obj>"                 );
		public static readonly Opcode Ceq_var  = new(0x25, &Opcode.Functions.Ceq,              "ceq <var>"                 );
		public static readonly Opcode Cge_obj  = new(0x08, &Opcode.Functions.Cge,              "cge <obj>"                 );
		public static readonly Opcode Cge_var  = new(0x28, &Opcode.Functions.Cge,              "cge <var>"                 );
		public static readonly Opcode Cgt_obj  = new(0x06, &Opcode.Functions.Cgt,              "cgt <obj>"                 );
		public static readonly Opcode Cgt_var  = new(0x26, &Opcode.Functions.Cgt,              "cgt <var>"                 );
		public static readonly Opcode Clc      = new(0x0F, &Opcode.Functions.Clc,              "clc"                       );
		public static readonly Opcode Cle_obj  = new(0x09, &Opcode.Functions.Cle,              "cle <obj>"                 );
		public static readonly Opcode Cle_var  = new(0x29, &Opcode.Functions.Cle,              "cle <var>"                 );
		public static readonly Opcode Cln      = new(0x1F, &Opcode.Functions.Cln,              "cln"                       );
		public static readonly Opcode Clo      = new(0x2F, &Opcode.Functions.Clo,              "clo"                       );
		public static readonly Opcode Clp      = new(0x6F, &Opcode.Functions.Clp,              "clp"                       );
		public static readonly Opcode Clr      = new(0x3F, &Opcode.Functions.Clr,              "clr"                       );
		public static readonly Opcode Cls      = new(0xFD, &Opcode.Functions.Cls,              "cls"                       );
		public static readonly Opcode Clt_obj  = new(0x05, &Opcode.Functions.Clt,              "clt <obj>"                 );
		public static readonly Opcode Ctl_var  = new(0x25, &Opcode.Functions.Clt,              "clt <var>"                 );
		public static readonly Opcode Clz      = new(0x4F, &Opcode.Functions.Clr,              "clz"                       );
		public static readonly Opcode Cnrb     = new(0xFC, &Opcode.Functions.Cnrb,             "cnrb"                      );
		public static readonly Opcode Cnrf     = new(0xFB, &Opcode.Functions.Cnrf,             "cnrf"                      );
		public static readonly Opcode Cnwh     = new(0xF9, &Opcode.Functions.Cnwh,             "cnwh"                      );
		public static readonly Opcode Cnww     = new(0xF8, &Opcode.Functions.Cnww,             "cnww"                      );
		public static readonly Opcode Conh     = new(0xF1, &Opcode.Functions.Conh,             "conh"                      );
		public static readonly Opcode Conr     = new(0xFA, &Opcode.Functions.Conr,             "conr"                      );
		public static readonly Opcode Cont     = new(0xF2, &Opcode.Functions.Cont,             "cont"                      );
		public static readonly Opcode Conw     = new(0xF0, &Opcode.Functions.Conw,             "conw"                      );
		public static readonly Opcode Cpcj     = new(0xE4, &Opcode.Functions.Cpcj,             "cpcj"                      );
		public static readonly Opcode Cpco     = new(0xE2, &Opcode.Functions.Cpco,             "cpco"                      );
		public static readonly Opcode Cpi      = new(0xE8, &Opcode.Functions.Cpi,              "cpi"                       );
		public static readonly Opcode Cpnr     = new(0xE6, &Opcode.Functions.Cpnr,             "cpnr"                      );
		public static readonly Opcode Cpo      = new(0xE3, &Opcode.Functions.Cpo,              "cpo"                       );
		public static readonly Opcode Cpr      = new(0xE7, &Opcode.Functions.Cpr,              "cpr"                       );
		public static readonly Opcode Cpro     = new(0xE1, &Opcode.Functions.Cpro,             "cpro"                      );
		public static readonly Opcode Cprv     = new(0xE5, &Opcode.Functions.Cprv,             "cprv"                      );
		public static readonly Opcode Cpz      = new(0xE0, &Opcode.Functions.Cpz,              "cpz"                       );

		public static readonly Opcode Dex      = new(0x81, &Opcode.Functions.Dex,              "dex"                       );
		public static readonly Opcode Dey      = new(0x83, &Opcode.Functions.Dey,              "dey"                       );
		public static readonly Opcode Div_obj  = new(0x33, &Opcode.Functions.Div,              "div <obj>"                 );
		public static readonly Opcode Div_var  = new(0x43, &Opcode.Functions.Div,              "div <var>"                 );
			public static readonly Opcode Dtad_obj = new(0x00, &Opcode.Functions.Dtad,         "dtad <obj>"                );
			public static readonly Opcode Dtad_var = new(0x08, &Opcode.Functions.Dtad,         "dtad <var>"                );
			public static readonly Opcode Dtah_obj = new(0x01, &Opcode.Functions.Dtah,         "dtah <obj>"                );
			public static readonly Opcode Dtah_var = new(0x09, &Opcode.Functions.Dtah,         "dtah <var>"                );
			public static readonly Opcode Dtai_obj = new(0x02, &Opcode.Functions.Dtai,         "dtai <obj>"                );
			public static readonly Opcode Dtai_var = new(0x0A, &Opcode.Functions.Dtai,         "dtai <var>"                );
			public static readonly Opcode Dtam_obj = new(0x03, &Opcode.Functions.Dtam,         "dtam <obj>"                );
			public static readonly Opcode Dtam_var = new(0x0B, &Opcode.Functions.Dtam,         "dtam <var>"                );
			public static readonly Opcode Dtao_obj = new(0x04, &Opcode.Functions.Dtao,         "dtao <obj>"                );
			public static readonly Opcode Dtao_var = new(0x0C, &Opcode.Functions.Dtao,         "dtao <var>"                );
			public static readonly Opcode Dtat_obj = new(0x05, &Opcode.Functions.Dtat,         "dtat <obj>"                );
			public static readonly Opcode Dtat_var = new(0x0D, &Opcode.Functions.Dtat,         "dtat <var>"                );
			public static readonly Opcode Dtas_obj = new(0x06, &Opcode.Functions.Dtas,         "dtas <obj>"                );
			public static readonly Opcode Dtas_var = new(0x0E, &Opcode.Functions.Dtas,         "dtas <var>"                );
			public static readonly Opcode Dtay_obj = new(0x07, &Opcode.Functions.Dtay,         "dtay <obj>"                );
			public static readonly Opcode Dtay_var = new(0x0F, &Opcode.Functions.Dtay,         "dtay <var>"                );
			public static readonly Opcode Dtd      = new(0x10, &Opcode.Functions.Dtd,          "dtd"                       );
			public static readonly Opcode Dte      = new(0x22, &Opcode.Functions.Dte,          "dte"                       );
			public static readonly Opcode Dtfm     = new(0x20, &Opcode.Functions.Dtfm,         "dtfm"                      );
			public static readonly Opcode Dth      = new(0x11, &Opcode.Functions.Dth,          "dth"                       );
			public static readonly Opcode Dti      = new(0x12, &Opcode.Functions.Dti,          "dti"                       );
			public static readonly Opcode Dtm      = new(0x13, &Opcode.Functions.Dtm,          "dtm"                       );
			public static readonly Opcode Dtn      = new(0x21, &Opcode.Functions.Dtn,          "dtn"                       );
			public static readonly Opcode Dto      = new(0x14, &Opcode.Functions.Dto,          "dto"                       );
			public static readonly Opcode Dtt      = new(0x15, &Opcode.Functions.Dtt,          "dtt"                       );
			public static readonly Opcode Dts      = new(0x16, &Opcode.Functions.Dts,          "dts"                       );
			public static readonly Opcode Dty      = new(0x17, &Opcode.Functions.Dty,          "dty"                       );
		public static readonly Opcode Dt       = new(0x5E, &Opcode.Functions.Ext,              "<extended opcode>",
			Dtad_obj, Dtad_var,
			Dtah_obj, Dtah_var,
			Dtai_obj, Dtai_var,
			Dtam_obj, Dtam_var,
			Dtao_obj, Dtao_var,
			Dtat_obj, Dtat_var,
			Dtas_obj, Dtas_var,
			Dtay_obj, Dtay_var,
			Dtd,
			Dte,
			Dtfm,
			Dth,
			Dti,
			Dtm,
			Dtn,
			Dto,
			Dtt,
			Dts,
			Dty                                                                                                            );
		public static readonly Opcode Dup      = new(0x4D, &Opcode.Functions.Dup,              "dup"                       );
		public static readonly Opcode Dupd     = new(0x5D, &Opcode.Functions.Dupd,             "dupd"                      );

		public static readonly Opcode Err      = new(0x61, &Opcode.Functions.Err,              "err"                       );
		public static readonly Opcode Err_obj  = new(0x71, &Opcode.Functions.Err,              "err <obj>"                 );
		public static readonly Opcode Exp      = new(0x78, &Opcode.Functions.Exp,              "exp"                       );

		public static readonly Opcode Flor     = new(0x91, &Opcode.Functions.Flor,             "flor"                      );

		public static readonly Opcode Halt     = new(0xFF, &Opcode.Functions.Halt,             "halt"                      );

		public static readonly Opcode Idx_obj  = new(0x75, &Opcode.Functions.Idx,              "idx <obj>"                 );
		public static readonly Opcode Idx_var  = new(0x85, &Opcode.Functions.Idx,              "idx <var>"                 );
		public static readonly Opcode Idxv     = new(0x87, &Opcode.Functions.Idxv,             "idxv"                      );
		public static readonly Opcode Inc      = new(0x48, &Opcode.Functions.Inc,              "inc"                       );
		public static readonly Opcode Incb     = new(0x49, &Opcode.Functions.Incb,             "incb"                      );
		public static readonly Opcode Inl      = new(0x47, &Opcode.Functions.Inl,              "inl"                       );
		public static readonly Opcode Intp     = new(0x57, &Opcode.Functions.Intp,             "intp"                      );
		public static readonly Opcode Inv      = new(0x5A, &Opcode.Functions.Inv,              "inv"                       );
		public static readonly Opcode Inx      = new(0x80, &Opcode.Functions.Inx,              "inx"                       );
		public static readonly Opcode Iny      = new(0x82, &Opcode.Functions.Iny,              "iny"                       );
			public static readonly Opcode Iob_obj          = new(0x40, &Opcode.Functions.Iob,  "iob <obj>"                 );
			public static readonly Opcode Iob_var          = new(0x41, &Opcode.Functions.Iob,  "iob <var>"                 );
			public static readonly Opcode Ioc_obj          = new(0x42, &Opcode.Functions.Ioc,  "ioc <obj>"                 );
			public static readonly Opcode Ioc_var          = new(0x43, &Opcode.Functions.Ioc,  "iob <var>"                 );
			public static readonly Opcode Iofp_obj_obj_obj = new(0x30, &Opcode.Functions.Iofp, "iofp <obj>, <obj2>, <obj3>");
			public static readonly Opcode Iofp_obj_obj_var = new(0x31, &Opcode.Functions.Iofp, "iofp <obj>, <obj2>, <var>" );
			public static readonly Opcode Iofp_obj_var_obj = new(0x32, &Opcode.Functions.Iofp, "iofp <obj>, <var>, <obj2>" );
			public static readonly Opcode Iofp_obj_var_var = new(0x33, &Opcode.Functions.Iofp, "iofp <obj>, <var>, <var2>" );
			public static readonly Opcode Iofp_var_obj_obj = new(0x34, &Opcode.Functions.Iofp, "iofp <var>, <obj>, <obj2>" );
			public static readonly Opcode Iofp_var_obj_var = new(0x35, &Opcode.Functions.Iofp, "iofp <var>, <obj>, <var2>" );
			public static readonly Opcode Iofp_var_var_obj = new(0x36, &Opcode.Functions.Iofp, "iofp <var>, <var2>, <obj>" );
			public static readonly Opcode Iofp_var_var_var = new(0x37, &Opcode.Functions.Iofp, "iofp <var>, <var2>, <var3>");
			public static readonly Opcode Ior_obj          = new(0x00, &Opcode.Functions.Ior,  "ior <obj>, <type>"         );
			public static readonly Opcode Ior_var          = new(0x01, &Opcode.Functions.Ior,  "ior <var>, <type>"         );
			public static readonly Opcode Ios_obj_obj_obj  = new(0x20, &Opcode.Functions.Ios,  "ios <obj>, <obj2>, <obj3>" );
			public static readonly Opcode Ios_obj_obj_var  = new(0x21, &Opcode.Functions.Ios,  "ios <obj>, <obj2>, <var>"  );
			public static readonly Opcode Ios_obj_var_obj  = new(0x22, &Opcode.Functions.Ios,  "ios <obj>, <var>, <obj2>"  );
			public static readonly Opcode Ios_obj_var_var  = new(0x23, &Opcode.Functions.Ios,  "ios <obj>, <var>, <var2>"  );
			public static readonly Opcode Ios_var_obj_obj  = new(0x24, &Opcode.Functions.Ios,  "ios <var>, <obj>, <obj2>"  );
			public static readonly Opcode Ios_var_obj_var  = new(0x25, &Opcode.Functions.Ios,  "ios <var>, <obj>, <var2>"  );
			public static readonly Opcode Ios_var_var_obj  = new(0x26, &Opcode.Functions.Ios,  "ios <var>, <var2>, <obj>"  );
			public static readonly Opcode Ios_var_var_var  = new(0x27, &Opcode.Functions.Ios,  "ios <var>, <var2>, <var3>" );
			public static readonly Opcode Ios_obj_obj      = new(0x28, &Opcode.Functions.Ios,  "ios <obj>, <obj2>"         );
			public static readonly Opcode Ios_var_obj      = new(0x29, &Opcode.Functions.Ios,  "ios <var>, <obj>"          );
			public static readonly Opcode Ios_obj_var      = new(0x2A, &Opcode.Functions.Ios,  "ios <obj>, <var>"          );
			public static readonly Opcode Ios_var_var      = new(0x2B, &Opcode.Functions.Ios,  "ios <var>, <var2>"         );
			public static readonly Opcode Iow_obj_obj      = new(0x10, &Opcode.Functions.Iow,  "iow <obj>, <obj2>"         );
			public static readonly Opcode Iow_var_obj      = new(0x11, &Opcode.Functions.Iow,  "iow <var>, <obj>"          );
			public static readonly Opcode Iow_obj_var      = new(0x12, &Opcode.Functions.Iow,  "iow <obj>, <var>"          );
			public static readonly Opcode Iow_var_var      = new(0x13, &Opcode.Functions.Iow,  "iow <var>, <var2>"         );
		public static readonly Opcode Is       = new(0x60, &Opcode.Functions.Is,               "is <type>"                 );
		public static readonly Opcode Isa      = new(0x62, &Opcode.Functions.Isa,              "isa <type>"                );
	}
}
