namespace Chips.Core.Specifications{
	public static unsafe class Opcodes{
		public static readonly Opcode Abs              = new(0x39, &Opcode.Functions.Abs,     "abs"                         );
		public static readonly Opcode Acos             = new(0xA3, &Opcode.Functions.Acos,    "acos"                        );
		public static readonly Opcode Acsh             = new(0xA5, &Opcode.Functions.Acsh,    "acsh"                        );
		public static readonly Opcode Add_obj          = new(0x30, &Opcode.Functions.Add,     "add <obj>"                   );
		public static readonly Opcode Add_var          = new(0x40, &Opcode.Functions.Add,     "add <var>"                   );
		public static readonly Opcode And_obj          = new(0x00, &Opcode.Functions.And,     "and <obj>"                   );
		public static readonly Opcode And_var          = new(0x20, &Opcode.Functions.And,     "and <var>"                   );
		public static readonly Opcode Art_obj          = new(0x35, &Opcode.Functions.Art,     "art <obj>"                   );
		public static readonly Opcode Art_var          = new(0x45, &Opcode.Functions.Art,     "art <var>"                   );
		public static readonly Opcode Asin             = new(0xA2, &Opcode.Functions.Asin,    "asin"                        );
		public static readonly Opcode Asl              = new(0x0D, &Opcode.Functions.Asl,     "asl"                         );
		public static readonly Opcode Asnh             = new(0x95, &Opcode.Functions.Asnh,    "asnh"                        );
		public static readonly Opcode Asr              = new(0x0E, &Opcode.Functions.Asr,     "asr"                         );
		public static readonly Opcode Atan             = new(0xA4, &Opcode.Functions.Atan,    "atan"                        );
		public static readonly Opcode Atnh             = new(0xB5, &Opcode.Functions.Atnh,    "atnh"                        );
		public static readonly Opcode Atnt_obj         = new(0xC4, &Opcode.Functions.Atnt,    "atnt <obj>"                  );
		public static readonly Opcode Atnt_var         = new(0xD4, &Opcode.Functions.Atnt,    "atnt <var>"                  );

		public static readonly Opcode Bfc              = new(0x11, &Opcode.Functions.Br,      "bfc <label>"                 );
		public static readonly Opcode Bfn              = new(0x13, &Opcode.Functions.Br,      "bfn <label>"                 );
		public static readonly Opcode Bfo              = new(0x15, &Opcode.Functions.Br,      "bfo <label>"                 );
		public static readonly Opcode Bfp              = new(0x84, &Opcode.Functions.Br,      "bfp <label>"                 );
		public static readonly Opcode Bfr              = new(0x17, &Opcode.Functions.Br,      "bfr <label>"                 );
		public static readonly Opcode Bfz              = new(0x19, &Opcode.Functions.Br,      "bfz <label>"                 );
		public static readonly Opcode Blg              = new(0x38, &Opcode.Functions.Blg,     "blg"                         );
		public static readonly Opcode Br               = new(0x1A, &Opcode.Functions.Br,      "br <label>"                  );
		public static readonly Opcode Brf_obj          = new(0x7C, &Opcode.Functions.Br,      "brf <obj>, <label>"          );
		public static readonly Opcode Brf_var          = new(0x7D, &Opcode.Functions.Br,      "brf <var>, <label>"          );
		public static readonly Opcode Brt_obj          = new(0x7A, &Opcode.Functions.Br,      "brt <obj>, <label>"          );
		public static readonly Opcode Brt_var          = new(0x7B, &Opcode.Functions.Br,      "brt <var>, <label>"          );
		public static readonly Opcode Btc              = new(0x10, &Opcode.Functions.Br,      "btc <label>"                 );
		public static readonly Opcode Btn              = new(0x12, &Opcode.Functions.Br,      "btn <label>"                 );
		public static readonly Opcode Bto              = new(0x14, &Opcode.Functions.Br,      "bto <label>"                 );
		public static readonly Opcode Btp              = new(0x74, &Opcode.Functions.Br,      "btp <label>"                 );
		public static readonly Opcode Btr              = new(0x16, &Opcode.Functions.Br,      "btr <label>"                 );
		public static readonly Opcode Btz              = new(0x18, &Opcode.Functions.Br,      "btz <label>"                 );
		public static readonly Opcode Bin              = new(0x67, &Opcode.Functions.Bin,     "bin"                         );
		public static readonly Opcode Binz             = new(0x68, &Opcode.Functions.Binz,    "binz"                        );
		public static readonly Opcode Bit_obj          = new(0x69, &Opcode.Functions.Bit,     "bit <obj>"                   );
		public static readonly Opcode Bit_var          = new(0x79, &Opcode.Functions.Bit,     "bit <var>"                   );
		public static readonly Opcode Bits             = new(0x6A, &Opcode.Functions.Bits,    "bits"                        );

		public static readonly Opcode Call             = new(0x1B, &Opcode.Functions.Call,    "call <func>"                 );
		public static readonly Opcode Caps             = new(0xF7, &Opcode.Functions.Caps,    "caps"                        );
		public static readonly Opcode Cast             = new(0x63, &Opcode.Functions.Cast,    "cast <type>"                 );
		public static readonly Opcode Cclb             = new(0xF5, &Opcode.Functions.Cclb,    "cclb"                        );
		public static readonly Opcode Cclf             = new(0xF6, &Opcode.Functions.Cclf,    "cclf"                        );
		public static readonly Opcode Ceil             = new(0xA1, &Opcode.Functions.Ceil,    "ceil"                        );
		public static readonly Opcode Ceq_obj          = new(0x05, &Opcode.Functions.Ceq,     "ceq <obj>"                   );
		public static readonly Opcode Ceq_var          = new(0x25, &Opcode.Functions.Ceq,     "ceq <var>"                   );
		public static readonly Opcode Cge_obj          = new(0x08, &Opcode.Functions.Cge,     "cge <obj>"                   );
		public static readonly Opcode Cge_var          = new(0x28, &Opcode.Functions.Cge,     "cge <var>"                   );
		public static readonly Opcode Cgt_obj          = new(0x06, &Opcode.Functions.Cgt,     "cgt <obj>"                   );
		public static readonly Opcode Cgt_var          = new(0x26, &Opcode.Functions.Cgt,     "cgt <var>"                   );
		public static readonly Opcode Clc              = new(0x0F, &Opcode.Functions.Clc,     "clc"                         );
		public static readonly Opcode Cle_obj          = new(0x09, &Opcode.Functions.Cle,     "cle <obj>"                   );
		public static readonly Opcode Cle_var          = new(0x29, &Opcode.Functions.Cle,     "cle <var>"                   );
		public static readonly Opcode Cln              = new(0x1F, &Opcode.Functions.Cln,     "cln"                         );
		public static readonly Opcode Clo              = new(0x2F, &Opcode.Functions.Clo,     "clo"                         );
		public static readonly Opcode Clp              = new(0x6F, &Opcode.Functions.Clp,     "clp"                         );
		public static readonly Opcode Clr              = new(0x3F, &Opcode.Functions.Clr,     "clr"                         );
		public static readonly Opcode Cls              = new(0xFD, &Opcode.Functions.Cls,     "cls"                         );
		public static readonly Opcode Clt_obj          = new(0x05, &Opcode.Functions.Clt,     "clt <obj>"                   );
		public static readonly Opcode Ctl_var          = new(0x25, &Opcode.Functions.Clt,     "clt <var>"                   );
		public static readonly Opcode Clz              = new(0x4F, &Opcode.Functions.Clr,     "clz"                         );
		public static readonly Opcode Cnrb             = new(0xFC, &Opcode.Functions.Cnrb,    "cnrb"                        );
		public static readonly Opcode Cnrf             = new(0xFB, &Opcode.Functions.Cnrf,    "cnrf"                        );
		public static readonly Opcode Cnwh             = new(0xF9, &Opcode.Functions.Cnwh,    "cnwh"                        );
		public static readonly Opcode Cnww             = new(0xF8, &Opcode.Functions.Cnww,    "cnww"                        );
		public static readonly Opcode Conh             = new(0xF1, &Opcode.Functions.Conh,    "conh"                        );
		public static readonly Opcode Conr             = new(0xFA, &Opcode.Functions.Conr,    "conr"                        );
		public static readonly Opcode Cont             = new(0xF2, &Opcode.Functions.Cont,    "cont"                        );
		public static readonly Opcode Conw             = new(0xF0, &Opcode.Functions.Conw,    "conw"                        );
		public static readonly Opcode Cos              = new(0x93, &Opcode.Functions.Cos,     "cos"                         );
		public static readonly Opcode Cosh             = new(0xB3, &Opcode.Functions.Cosh,    "cosh"                        );
		public static readonly Opcode Cpcj             = new(0xE4, &Opcode.Functions.Cpcj,    "cpcj"                        );
		public static readonly Opcode Cpco             = new(0xE2, &Opcode.Functions.Cpco,    "cpco"                        );
		public static readonly Opcode Cpi              = new(0xE8, &Opcode.Functions.Cpi,     "cpi"                         );
		public static readonly Opcode Cpnr             = new(0xE6, &Opcode.Functions.Cpnr,    "cpnr"                        );
		public static readonly Opcode Cpo              = new(0xE3, &Opcode.Functions.Cpo,     "cpo"                         );
		public static readonly Opcode Cpr              = new(0xE7, &Opcode.Functions.Cpr,     "cpr"                         );
		public static readonly Opcode Cpro             = new(0xE1, &Opcode.Functions.Cpro,    "cpro"                        );
		public static readonly Opcode Cprv             = new(0xE5, &Opcode.Functions.Cprv,    "cprv"                        );
		public static readonly Opcode Cpz              = new(0xE0, &Opcode.Functions.Cpz,     "cpz"                         );

		public static readonly Opcode Dex              = new(0x81, &Opcode.Functions.Dex,     "dex"                         );
		public static readonly Opcode Dey              = new(0x83, &Opcode.Functions.Dey,     "dey"                         );
		public static readonly Opcode Div_obj          = new(0x33, &Opcode.Functions.Div,     "div <obj>"                   );
		public static readonly Opcode Div_var          = new(0x43, &Opcode.Functions.Div,     "div <var>"                   );
		public static readonly Opcode Dtad_obj         = new(0x00, &Opcode.Functions.Dtad,    "dtad <obj>"                  );
		public static readonly Opcode Dtad_var         = new(0x08, &Opcode.Functions.Dtad,    "dtad <var>"                  );
		public static readonly Opcode Dtah_obj         = new(0x01, &Opcode.Functions.Dtah,    "dtah <obj>"                  );
		public static readonly Opcode Dtah_var         = new(0x09, &Opcode.Functions.Dtah,    "dtah <var>"                  );
		public static readonly Opcode Dtai_obj         = new(0x02, &Opcode.Functions.Dtai,    "dtai <obj>"                  );
		public static readonly Opcode Dtai_var         = new(0x0A, &Opcode.Functions.Dtai,    "dtai <var>"                  );
		public static readonly Opcode Dtam_obj         = new(0x03, &Opcode.Functions.Dtam,    "dtam <obj>"                  );
		public static readonly Opcode Dtam_var         = new(0x0B, &Opcode.Functions.Dtam,    "dtam <var>"                  );
		public static readonly Opcode Dtao_obj         = new(0x04, &Opcode.Functions.Dtao,    "dtao <obj>"                  );
		public static readonly Opcode Dtao_var         = new(0x0C, &Opcode.Functions.Dtao,    "dtao <var>"                  );
		public static readonly Opcode Dtat_obj         = new(0x05, &Opcode.Functions.Dtat,    "dtat <obj>"                  );
		public static readonly Opcode Dtat_var         = new(0x0D, &Opcode.Functions.Dtat,    "dtat <var>"                  );
		public static readonly Opcode Dtas_obj         = new(0x06, &Opcode.Functions.Dtas,    "dtas <obj>"                  );
		public static readonly Opcode Dtas_var         = new(0x0E, &Opcode.Functions.Dtas,    "dtas <var>"                  );
		public static readonly Opcode Dtay_obj         = new(0x07, &Opcode.Functions.Dtay,    "dtay <obj>"                  );
		public static readonly Opcode Dtay_var         = new(0x0F, &Opcode.Functions.Dtay,    "dtay <var>"                  );
		public static readonly Opcode Dtd              = new(0x10, &Opcode.Functions.Dtd,     "dtd"                         );
		public static readonly Opcode Dte              = new(0x22, &Opcode.Functions.Dte,     "dte"                         );
		public static readonly Opcode Dtfm             = new(0x20, &Opcode.Functions.Dtfm,    "dtfm"                        );
		public static readonly Opcode Dth              = new(0x11, &Opcode.Functions.Dth,     "dth"                         );
		public static readonly Opcode Dti              = new(0x12, &Opcode.Functions.Dti,     "dti"                         );
		public static readonly Opcode Dtm              = new(0x13, &Opcode.Functions.Dtm,     "dtm"                         );
		public static readonly Opcode Dtn              = new(0x21, &Opcode.Functions.Dtn,     "dtn"                         );
		public static readonly Opcode Dto              = new(0x14, &Opcode.Functions.Dto,     "dto"                         );
		public static readonly Opcode Dtt              = new(0x15, &Opcode.Functions.Dtt,     "dtt"                         );
		public static readonly Opcode Dts              = new(0x16, &Opcode.Functions.Dts,     "dts"                         );
		public static readonly Opcode Dty              = new(0x17, &Opcode.Functions.Dty,     "dty"                         );
		public static readonly Opcode Dt               = new(0x5E, &Opcode.Functions.Ext,     "<extended opcode>",
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
			Dty                                                                                                             );
		public static readonly Opcode Dup              = new(0x4D, &Opcode.Functions.Dup,     "dup"                         );
		public static readonly Opcode Dupd             = new(0x5D, &Opcode.Functions.Dupd,    "dupd"                        );

		public static readonly Opcode Err              = new(0x61, &Opcode.Functions.Err,     "err"                         );
		public static readonly Opcode Err_obj          = new(0x71, &Opcode.Functions.Err,     "err <obj>"                   );
		public static readonly Opcode Exp              = new(0x78, &Opcode.Functions.Exp,     "exp"                         );

		public static readonly Opcode Flor             = new(0x91, &Opcode.Functions.Flor,    "flor"                        );

		public static readonly Opcode Halt             = new(0xFF, &Opcode.Functions.Halt,    "halt"                        );

		public static readonly Opcode Idx_obj          = new(0x75, &Opcode.Functions.Idx,     "idx <obj>"                   );
		public static readonly Opcode Idx_var          = new(0x85, &Opcode.Functions.Idx,     "idx <var>"                   );
		public static readonly Opcode Idxv             = new(0x87, &Opcode.Functions.Idxv,    "idxv"                        );
		public static readonly Opcode Inc              = new(0x48, &Opcode.Functions.Inc,     "inc"                         );
		public static readonly Opcode Incb             = new(0x49, &Opcode.Functions.Incb,    "incb"                        );
		public static readonly Opcode Inl              = new(0x47, &Opcode.Functions.Inl,     "inl"                         );
		public static readonly Opcode Intp             = new(0x57, &Opcode.Functions.Intp,    "intp"                        );
		public static readonly Opcode Inv              = new(0x5A, &Opcode.Functions.Inv,     "inv"                         );
		public static readonly Opcode Inx              = new(0x80, &Opcode.Functions.Inx,     "inx"                         );
		public static readonly Opcode Iny              = new(0x82, &Opcode.Functions.Iny,     "iny"                         );
		public static readonly Opcode Iob_obj          = new(0x40, &Opcode.Functions.Iob,     "iob <obj>"                   );
		public static readonly Opcode Iob_var          = new(0x41, &Opcode.Functions.Iob,     "iob <var>"                   );
		public static readonly Opcode Ioc_obj          = new(0x42, &Opcode.Functions.Ioc,     "ioc <obj>"                   );
		public static readonly Opcode Ioc_var          = new(0x43, &Opcode.Functions.Ioc,     "iob <var>"                   );
		public static readonly Opcode Iofp_obj_obj_obj = new(0x30, &Opcode.Functions.Iofp,    "iofp <obj>, <obj2>, <obj3>"  );
		public static readonly Opcode Iofp_obj_obj_var = new(0x31, &Opcode.Functions.Iofp,    "iofp <obj>, <obj2>, <var>"   );
		public static readonly Opcode Iofp_obj_var_obj = new(0x32, &Opcode.Functions.Iofp,    "iofp <obj>, <var>, <obj2>"   );
		public static readonly Opcode Iofp_obj_var_var = new(0x33, &Opcode.Functions.Iofp,    "iofp <obj>, <var>, <var2>"   );
		public static readonly Opcode Iofp_var_obj_obj = new(0x34, &Opcode.Functions.Iofp,    "iofp <var>, <obj>, <obj2>"   );
		public static readonly Opcode Iofp_var_obj_var = new(0x35, &Opcode.Functions.Iofp,    "iofp <var>, <obj>, <var2>"   );
		public static readonly Opcode Iofp_var_var_obj = new(0x36, &Opcode.Functions.Iofp,    "iofp <var>, <var2>, <obj>"   );
		public static readonly Opcode Iofp_var_var_var = new(0x37, &Opcode.Functions.Iofp,    "iofp <var>, <var2>, <var3>"  );
		public static readonly Opcode Ior_obj          = new(0x00, &Opcode.Functions.Ior,     "ior <obj>, <type>"           );
		public static readonly Opcode Ior_var          = new(0x01, &Opcode.Functions.Ior,     "ior <var>, <type>"           );
		public static readonly Opcode Ios_obj_obj_obj  = new(0x20, &Opcode.Functions.Ios,     "ios <obj>, <obj2>, <obj3>"   );
		public static readonly Opcode Ios_obj_obj_var  = new(0x21, &Opcode.Functions.Ios,     "ios <obj>, <obj2>, <var>"    );
		public static readonly Opcode Ios_obj_var_obj  = new(0x22, &Opcode.Functions.Ios,     "ios <obj>, <var>, <obj2>"    );
		public static readonly Opcode Ios_obj_var_var  = new(0x23, &Opcode.Functions.Ios,     "ios <obj>, <var>, <var2>"    );
		public static readonly Opcode Ios_var_obj_obj  = new(0x24, &Opcode.Functions.Ios,     "ios <var>, <obj>, <obj2>"    );
		public static readonly Opcode Ios_var_obj_var  = new(0x25, &Opcode.Functions.Ios,     "ios <var>, <obj>, <var2>"    );
		public static readonly Opcode Ios_var_var_obj  = new(0x26, &Opcode.Functions.Ios,     "ios <var>, <var2>, <obj>"    );
		public static readonly Opcode Ios_var_var_var  = new(0x27, &Opcode.Functions.Ios,     "ios <var>, <var2>, <var3>"   );
		public static readonly Opcode Ios_obj_obj      = new(0x28, &Opcode.Functions.Ios,     "ios <obj>, <obj2>"           );
		public static readonly Opcode Ios_var_obj      = new(0x29, &Opcode.Functions.Ios,     "ios <var>, <obj>"            );
		public static readonly Opcode Ios_obj_var      = new(0x2A, &Opcode.Functions.Ios,     "ios <obj>, <var>"            );
		public static readonly Opcode Ios_var_var      = new(0x2B, &Opcode.Functions.Ios,     "ios <var>, <var2>"           );
		public static readonly Opcode Iow_obj_obj      = new(0x10, &Opcode.Functions.Iow,     "iow <obj>, <obj2>"           );
		public static readonly Opcode Iow_var_obj      = new(0x11, &Opcode.Functions.Iow,     "iow <var>, <obj>"            );
		public static readonly Opcode Iow_obj_var      = new(0x12, &Opcode.Functions.Iow,     "iow <obj>, <var>"            );
		public static readonly Opcode Iow_var_var      = new(0x13, &Opcode.Functions.Iow,     "iow <var>, <var2>"           );
		public static readonly Opcode Io               = new(0x65, &Opcode.Functions.Ext,     "<extended opcode>",
			Iob_obj, Iob_var,
			Ioc_obj, Ioc_var,
			Iofp_obj_obj_obj, Iofp_obj_obj_var, Iofp_obj_var_obj, Iofp_obj_var_var, Iofp_var_obj_obj, Iofp_var_obj_var, Iofp_var_var_obj, Iofp_var_var_var,
			Ior_obj, Ior_var,
			Ios_obj_obj_obj, Ios_obj_obj_var, Ios_obj_var_obj, Ios_obj_var_var, Ios_var_obj_obj, Ios_var_obj_var, Ios_var_var_obj, Ios_var_var_var,
			Ios_obj_obj, Ios_var_obj, Ios_obj_var, Ios_var_var,
			Iow_obj_obj, Iow_var_obj, Iow_obj_var, Iow_var_var                                                              );
		public static readonly Opcode Is               = new(0x60, &Opcode.Functions.Is,      "is <type>"                   );
		public static readonly Opcode Isa              = new(0x62, &Opcode.Functions.Isa,     "isa <type>"                  );

		public static readonly Opcode Lda              = new(0x7E, &Opcode.Functions.Lda,     "lda <obj>"                   );
		public static readonly Opcode Ldrg             = new(0x5B, &Opcode.Functions.Ldrg,    "ldrg"                        );
		public static readonly Opcode Len              = new(0x22, &Opcode.Functions.Len,     "len"                         );
		public static readonly Opcode Lens             = new(0x73, &Opcode.Functions.Lens,    "lens"                        );
		public static readonly Opcode Ln               = new(0x36, &Opcode.Functions.Ln,      "ln"                          );
		public static readonly Opcode Log              = new(0x37, &Opcode.Functions.Log,     "log"                         );
		public static readonly Opcode Lscp             = new(0x6E, &Opcode.Functions.Lscp,    "lscp"                        );
		public static readonly Opcode Lsct             = new(0x6D, &Opcode.Functions.Lsct,    "lsct"                        );

		public static readonly Opcode Mov_var_obj      = new(0x46, &Opcode.Functions.Mov,     "mov <var>, <obj>"            );
		public static readonly Opcode Mov_var_var      = new(0x56, &Opcode.Functions.Mov,     "mov <var>, <var2>"           );
		public static readonly Opcode Mov_arrX_obj     = new(0x66, &Opcode.Functions.Mov,     "mov [<arr>, &X], <obj>"      );
		public static readonly Opcode Mov_arrY_obj     = new(0x76, &Opcode.Functions.Mov,     "mov [<arr>, &Y], <obj>"      );
		public static readonly Opcode Mov_var_arrX     = new(0x86, &Opcode.Functions.Mov,     "mov <var>, [<arr>, &X]"      );
		public static readonly Opcode Mov_var_arrY     = new(0x96, &Opcode.Functions.Mov,     "mov <var>, [<arr>, &Y]"      );
		public static readonly Opcode Mov_arrX_var     = new(0xA6, &Opcode.Functions.Mov,     "mov [<arr>, &X], <var>"      );
		public static readonly Opcode Mov_arrY_var     = new(0xB6, &Opcode.Functions.Mov,     "mov [<arr>, &Y], <var>"      );
		public static readonly Opcode Mul_obj          = new(0x32, &Opcode.Functions.Mul,     "mul <obj>"                   );
		public static readonly Opcode Mul_var          = new(0x42, &Opcode.Functions.Mul,     "mul <var>"                   );

		public static readonly Opcode Neg              = new(0x3A, &Opcode.Functions.Neg,     "neg"                         );
		public static readonly Opcode New_indexer      = new(0x00, &Opcode.Functions.New,     "new ^u32"                    );
		public static readonly Opcode New_array        = new(0x10, &Opcode.Functions.New,     "new ~arr:<type>"             );
		public static readonly Opcode New_date         = new(0x60, &Opcode.Functions.New,     "new ~date"                   );
		public static readonly Opcode New_date_obj     = new(0x61, &Opcode.Functions.New,     "new ~date, <obj>"            );
		public static readonly Opcode New_date_var     = new(0x62, &Opcode.Functions.New,     "new ~date, <var>"            );
		public static readonly Opcode New_list         = new(0x30, &Opcode.Functions.New,     "new ~list, &Y"               );
		public static readonly Opcode New_rand         = new(0x80, &Opcode.Functions.New,     "new ~rand"                   );
		public static readonly Opcode New_rand_obj     = new(0x81, &Opcode.Functions.New,     "new ~rand, <obj>"            );
		public static readonly Opcode New_rand_var     = new(0x82, &Opcode.Functions.New,     "new ~rand, <var>"            );
		public static readonly Opcode New_range        = new(0x20, &Opcode.Functions.New,     "new ~range"                  );
		public static readonly Opcode New_regex        = new(0x70, &Opcode.Functions.New,     "new ~regex"                  );
		public static readonly Opcode New_set          = new(0x50, &Opcode.Functions.New,     "new ~set"                    );
		public static readonly Opcode New_set_obj      = new(0x51, &Opcode.Functions.New,     "new ~set, <obj>"             );
		public static readonly Opcode New_set_var      = new(0x52, &Opcode.Functions.New,     "new ~set, <var>"             );
		public static readonly Opcode New_time         = new(0x40, &Opcode.Functions.New,     "new ~time"                   );
		public static readonly Opcode New_time_obj     = new(0x41, &Opcode.Functions.New,     "new ~time, <obj>"            );
		public static readonly Opcode New_time_var     = new(0x42, &Opcode.Functions.New,     "new ~time, <var>"            );
		public static readonly Opcode New_userdef      = new(0x90, &Opcode.Functions.New,     "new ~ud:<file::type>-><func>");
		public static readonly Opcode New              = new(0x2E, &Opcode.Functions.Ext,     "<extended opcode>",
			New_indexer,
			New_array,
			New_date, New_date_obj, New_date_var,
			New_list,
			New_rand, New_rand_obj, New_rand_var,
			New_range,
			New_regex,
			New_set, New_set_obj, New_set_var,
			New_time, New_time_obj, New_time_var,
			New_userdef                                                                                                     );
		public static readonly Opcode Not              = new(0x02, &Opcode.Functions.Not,     "not"                         );

		public static readonly Opcode Or_obj           = new(0x01, &Opcode.Functions.Or,      "or <obj>"                    );
		public static readonly Opcode Or_var           = new(0x21, &Opcode.Functions.Or,      "or <var>"                    );

		public static readonly Opcode Pntl             = new(0x4C, &Opcode.Functions.Pntl,    "pntl"                        );
		public static readonly Opcode Poa              = new(0x2A, &Opcode.Functions.Poa,     "poa"                         );
		public static readonly Opcode Poev             = new(0x98, &Opcode.Functions.Poev,    "poev <type>"                 );
		public static readonly Opcode Pop              = new(0x1C, &Opcode.Functions.Pop,     "pop"                         );
		public static readonly Opcode Pop_var          = new(0x3C, &Opcode.Functions.Pop,     "pop <var>"                   );
		public static readonly Opcode Pos              = new(0x3E, &Opcode.Functions.Pos,     "pos"                         );
		public static readonly Opcode Pow_obj          = new(0x34, &Opcode.Functions.Pow,     "pow <obj>"                   );
		public static readonly Opcode Pow_var          = new(0x44, &Opcode.Functions.Pow,     "pow <var>"                   );
		public static readonly Opcode Pox              = new(0x2B, &Opcode.Functions.Pox,     "pox"                         );
		public static readonly Opcode Poy              = new(0x2C, &Opcode.Functions.Poy,     "poy"                         );
		public static readonly Opcode Prnt             = new(0x4A, &Opcode.Functions.Prnt,    "prnt"                        );
		public static readonly Opcode Prse             = new(0x64, &Opcode.Functions.Prse,    "prse"                        );
		public static readonly Opcode Psa              = new(0x0A, &Opcode.Functions.Psa,     "psa"                         );
		public static readonly Opcode Psev             = new(0x88, &Opcode.Functions.Psev,    "psev <type>"                 );
		public static readonly Opcode Psh_obj          = new(0x3B, &Opcode.Functions.Psh,     "psh <obj>"                   );
		public static readonly Opcode Psh_var          = new(0x4B, &Opcode.Functions.Psh,     "psh <var>"                   );
		public static readonly Opcode Pss              = new(0x3D, &Opcode.Functions.Pss,     "pss"                         );
		public static readonly Opcode Psx              = new(0x0B, &Opcode.Functions.Psx,     "psx"                         );
		public static readonly Opcode Psy              = new(0x0C, &Opcode.Functions.Psy,     "psy"                         );

		public static readonly Opcode Rem_obj          = new(0x5C, &Opcode.Functions.Rem,     "rem <obj>"                   );
		public static readonly Opcode Rem_var          = new(0x6C, &Opcode.Functions.Rem,     "rem <var>"                   );
		public static readonly Opcode Ret              = new(0x04, &Opcode.Functions.Ret,     "ret"                         );
		public static readonly Opcode Rge              = new(0x8A, &Opcode.Functions.Rge,     "rge"                         );
		public static readonly Opcode Rge_obj          = new(0x9A, &Opcode.Functions.Rge,     "rge <obj>"                   );
		public static readonly Opcode Rge_var          = new(0xAA, &Opcode.Functions.Rge,     "rge <var>"                   );
		public static readonly Opcode Rgs              = new(0x89, &Opcode.Functions.Rgs,     "rgs"                         );
		public static readonly Opcode Rgs_obj          = new(0x99, &Opcode.Functions.Rgs,     "rgs <obj>"                   );
		public static readonly Opcode Rgs_var          = new(0xA9, &Opcode.Functions.Rgs,     "rgs <var>"                   );
		public static readonly Opcode Rgxf_obj         = new(0x97, &Opcode.Functions.Rgxf,    "rgxf <obj>"                  );
		public static readonly Opcode Rgxf_var         = new(0xA7, &Opcode.Functions.Rgxf,    "rgxf <var>"                  );
		public static readonly Opcode Rgxm_obj         = new(0xB1, &Opcode.Functions.Rgxm,    "rgxm <obj>"                  );
		public static readonly Opcode Rgxm_var         = new(0xA8, &Opcode.Functions.Rgxm,    "rgxm <var>"                  );
		public static readonly Opcode Rgxs             = new(0xB0, &Opcode.Functions.Rgxs,    "rgxf"                        );
		public static readonly Opcode Rndb             = new(0x40, &Opcode.Functions.Rndb,    "rndb <arr>"                  );
		public static readonly Opcode Rndd             = new(0x20, &Opcode.Functions.Rndd,    "rndd"                        );
		public static readonly Opcode Rndd_obj         = new(0x21, &Opcode.Functions.Rndd,    "rndd <obj>"                  );
		public static readonly Opcode Rndd_var         = new(0x22, &Opcode.Functions.Rndd,    "rndd <var>"                  );
		public static readonly Opcode Rndd_obj_obj     = new(0x23, &Opcode.Functions.Rndd,    "rndd <obj>, <obj2>"          );
		public static readonly Opcode Rndd_obj_var     = new(0x24, &Opcode.Functions.Rndd,    "rndd <obj>, <var>"           );
		public static readonly Opcode Rndd_var_obj     = new(0x25, &Opcode.Functions.Rndd,    "rndd <var>, <obj>"           );
		public static readonly Opcode Rndd_var_var     = new(0x26, &Opcode.Functions.Rndd,    "rndd <var>, <var2>"          );
		public static readonly Opcode Rndf             = new(0x10, &Opcode.Functions.Rndf,    "rndf"                        );
		public static readonly Opcode Rndf_obj         = new(0x11, &Opcode.Functions.Rndf,    "rndf <obj>"                  );
		public static readonly Opcode Rndf_var         = new(0x12, &Opcode.Functions.Rndf,    "rndf <var>"                  );
		public static readonly Opcode Rndf_obj_obj     = new(0x13, &Opcode.Functions.Rndf,    "rndf <obj>, <obj2>"          );
		public static readonly Opcode Rndf_obj_var     = new(0x14, &Opcode.Functions.Rndf,    "rndf <obj>, <var>"           );
		public static readonly Opcode Rndf_var_obj     = new(0x15, &Opcode.Functions.Rndf,    "rndf <var>, <obj>"           );
		public static readonly Opcode Rndf_var_var     = new(0x16, &Opcode.Functions.Rndf,    "rndf <var>, <var2>"          );
		public static readonly Opcode Rndi             = new(0x00, &Opcode.Functions.Rndi,    "rndi"                        );
		public static readonly Opcode Rndi_obj         = new(0x01, &Opcode.Functions.Rndi,    "rndi <obj>"                  );
		public static readonly Opcode Rndi_var         = new(0x02, &Opcode.Functions.Rndi,    "rndi <var>"                  );
		public static readonly Opcode Rndi_obj_obj     = new(0x03, &Opcode.Functions.Rndi,    "rndi <obj>, <obj2>"          );
		public static readonly Opcode Rndi_obj_var     = new(0x04, &Opcode.Functions.Rndi,    "rndi <obj>, <var>"           );
		public static readonly Opcode Rndi_var_obj     = new(0x05, &Opcode.Functions.Rndi,    "rndi <var>, <obj>"           );
		public static readonly Opcode Rndi_var_var     = new(0x06, &Opcode.Functions.Rndi,    "rndi <var>, <var2>"          );
		public static readonly Opcode Rndl             = new(0x30, &Opcode.Functions.Rndl,    "rndl"                        );
		public static readonly Opcode Rndl_obj         = new(0x31, &Opcode.Functions.Rndl,    "rndl <obj>"                  );
		public static readonly Opcode Rndl_var         = new(0x32, &Opcode.Functions.Rndl,    "rndl <var>"                  );
		public static readonly Opcode Rndl_obj_obj     = new(0x33, &Opcode.Functions.Rndl,    "rndl <obj>, <obj2>"          );
		public static readonly Opcode Rndl_obj_var     = new(0x34, &Opcode.Functions.Rndl,    "rndl <obj>, <var>"           );
		public static readonly Opcode Rndl_var_obj     = new(0x35, &Opcode.Functions.Rndl,    "rndl <var>, <obj>"           );
		public static readonly Opcode Rndl_var_var     = new(0x36, &Opcode.Functions.Rndl,    "rndl <var>, <var2>"          );
		public static readonly Opcode Rnd              = new(0x4E, &Opcode.Functions.Ext,     "<extended opcode>",
			Rndb,
			Rndd, Rndd_obj, Rndd_var, Rndd_obj_obj, Rndd_obj_var, Rndd_var_obj, Rndd_var_var,
			Rndf, Rndf_obj, Rndf_var, Rndf_obj_obj, Rndf_obj_var, Rndf_var_obj, Rndf_var_var,
			Rndi, Rndi_obj, Rndi_var, Rndi_obj_obj, Rndi_obj_var, Rndi_var_obj, Rndi_var_var,
			Rndl, Rndl_obj, Rndl_var, Rndl_obj_obj, Rndl_obj_var, Rndl_var_obj, Rndl_var_var                                );
		public static readonly Opcode Rol              = new(0x1D, &Opcode.Functions.Rol,     "rol"                         );
		public static readonly Opcode Ror              = new(0x1E, &Opcode.Functions.Ror,     "ror"                         );

		public static readonly Opcode Sbs              = new(0x70, &Opcode.Functions.Sbs,     "sbs"                         );
		public static readonly Opcode Sdiv_obj         = new(0xC1, &Opcode.Functions.Sdiv,    "sdiv <obj>"                  );
		public static readonly Opcode Sdiv_var         = new(0xD1, &Opcode.Functions.Sdiv,    "sdiv <var>"                  );
		public static readonly Opcode Shas_obj         = new(0xAB, &Opcode.Functions.Shas,    "shas <obj>"                  );
		public static readonly Opcode Shas_var         = new(0xBB, &Opcode.Functions.Shas,    "shas <var>"                  );
		public static readonly Opcode Sin              = new(0x92, &Opcode.Functions.Sin,     "sin"                         );
		public static readonly Opcode Sinh             = new(0xB2, &Opcode.Functions.Sinh,    "sinh"                        );
		public static readonly Opcode Sjn_obj          = new(0xC0, &Opcode.Functions.Sjn,     "sjn <obj>"                   );
		public static readonly Opcode Sjn_var          = new(0xD0, &Opcode.Functions.Sjn,     "sjn <var>"                   );
		public static readonly Opcode Sqrt             = new(0x77, &Opcode.Functions.Sqrt,    "sqrt"                        );
		public static readonly Opcode Srep             = new(0xC3, &Opcode.Functions.Srep,    "srep"                        );
		public static readonly Opcode Srmv_obj         = new(0xC2, &Opcode.Functions.Srmv,    "srmv <obj>"                  );
		public static readonly Opcode Srmv_var         = new(0xD2, &Opcode.Functions.Srmv,    "srmv <var>"                  );
		public static readonly Opcode Stc              = new(0x5F, &Opcode.Functions.Stc,     "stc"                         );
		public static readonly Opcode Stco_obj         = new(0x8E, &Opcode.Functions.Stco,    "stco <obj>"                  );
		public static readonly Opcode Stco_var         = new(0x9E, &Opcode.Functions.Stco,    "stco <var>"                  );
		public static readonly Opcode Stdf_obj         = new(0x8F, &Opcode.Functions.Stdf,    "stdf <obj>"                  );
		public static readonly Opcode Stdf_var         = new(0x9F, &Opcode.Functions.Stdf,    "stdf <var>"                  );
		public static readonly Opcode Stdj_obj         = new(0x8D, &Opcode.Functions.Stdj,    "stdj <obj>"                  );
		public static readonly Opcode Stdj_var         = new(0x9D, &Opcode.Functions.Stdj,    "stdj <var>"                  );
		public static readonly Opcode Stin_obj         = new(0x8C, &Opcode.Functions.Stin,    "stin <obj>"                  );
		public static readonly Opcode Stin_var         = new(0x9C, &Opcode.Functions.Stin,    "stin <var>"                  );
		public static readonly Opcode Stp              = new(0x7F, &Opcode.Functions.Stp,     "stp"                         );
		public static readonly Opcode Stun_obj         = new(0x8B, &Opcode.Functions.Stun,    "stun <obj>"                  );
		public static readonly Opcode Stun_var         = new(0x9B, &Opcode.Functions.Stun,    "stun <var>"                  );
		public static readonly Opcode Sub_obj          = new(0x31, &Opcode.Functions.Sub,     "sub <obj>"                   );
		public static readonly Opcode Sub_var          = new(0x41, &Opcode.Functions.Sub,     "sub <var>"                   );
		public static readonly Opcode Swap             = new(0x2D, &Opcode.Functions.Swap,    "swap"                        );
		public static readonly Opcode Sys_obj          = new(0xDF, &Opcode.Functions.Sys,     "sys <obj>"                   );
		public static readonly Opcode Sys_var          = new(0xEF, &Opcode.Functions.Sys,     "sys <var>"                   );

		public static readonly Opcode Tan              = new(0x94, &Opcode.Functions.Tan,     "tan"                         );
		public static readonly Opcode Tanh             = new(0xB4, &Opcode.Functions.Tanh,    "tanh"                        );
		public static readonly Opcode Tas              = new(0x58, &Opcode.Functions.Tas,     "tas"                         );
		public static readonly Opcode Tax              = new(0x51, &Opcode.Functions.Tax,     "tax"                         );
		public static readonly Opcode Tay              = new(0x52, &Opcode.Functions.Tay,     "tay"                         );
		public static readonly Opcode Tmad_obj         = new(0x00, &Opcode.Functions.Tmad,    "tmad <obj>"                  );
		public static readonly Opcode Tmad_var         = new(0x01, &Opcode.Functions.Tmad,    "tmad <var>"                  );
		public static readonly Opcode Tmah_obj         = new(0x02, &Opcode.Functions.Tmah,    "tmah <obj>"                  );
		public static readonly Opcode Tmah_var         = new(0x03, &Opcode.Functions.Tmah,    "tmah <var>"                  );
		public static readonly Opcode Tmai_obj         = new(0x04, &Opcode.Functions.Tmai,    "tmai <obj>"                  );
		public static readonly Opcode Tmai_var         = new(0x05, &Opcode.Functions.Tmai,    "tmai <var>"                  );
		public static readonly Opcode Tmam_obj         = new(0x06, &Opcode.Functions.Tmam,    "tmam <obj>"                  );
		public static readonly Opcode Tmam_var         = new(0x07, &Opcode.Functions.Tmam,    "tmam <var>"                  );
		public static readonly Opcode Tmas_obj         = new(0x0A, &Opcode.Functions.Tmas,    "tmas <obj>"                  );
		public static readonly Opcode Tmas_var         = new(0x0B, &Opcode.Functions.Tmas,    "tmas <var>"                  );
		public static readonly Opcode Tmat_obj         = new(0x08, &Opcode.Functions.Tmat,    "tmat <obj>"                  );
		public static readonly Opcode Tmat_var         = new(0x09, &Opcode.Functions.Tmat,    "tmat <var>"                  );
		public static readonly Opcode Tmcd             = new(0x10, &Opcode.Functions.Tmcd,    "tmcd"                        );
		public static readonly Opcode Tmch             = new(0x11, &Opcode.Functions.Tmch,    "tmch"                        );
		public static readonly Opcode Tmci             = new(0x12, &Opcode.Functions.Tmci,    "tmci"                        );
		public static readonly Opcode Tmcm             = new(0x13, &Opcode.Functions.Tmcm,    "tmcm"                        );
		public static readonly Opcode Tmcs             = new(0x15, &Opcode.Functions.Tmcs,    "tmcs"                        );
		public static readonly Opcode Tmfm             = new(0x20, &Opcode.Functions.Tmfm,    "tmfm"                        );
		public static readonly Opcode Tmt              = new(0x14, &Opcode.Functions.Tmt,     "tmt"                         );
		public static readonly Opcode Tmtd             = new(0x16, &Opcode.Functions.Tmtd,    "tmtd"                        );
		public static readonly Opcode Tmth             = new(0x17, &Opcode.Functions.Tmth,    "tmth"                        );
		public static readonly Opcode Tmti             = new(0x18, &Opcode.Functions.Tmti,    "tmti"                        );
		public static readonly Opcode Tmtm             = new(0x19, &Opcode.Functions.Tmtm,    "tmtm"                        );
		public static readonly Opcode Tmts             = new(0x1A, &Opcode.Functions.Tmts,    "tmts"                        );
		public static readonly Opcode Tm               = new(0x24, &Opcode.Functions.Ext,     "<extended opcode",
			Tmad_obj, Tmad_var,
			Tmah_obj, Tmah_var,
			Tmai_obj, Tmai_var,
			Tmam_obj, Tmam_var,
			Tmas_obj, Tmas_var,
			Tmat_obj, Tmat_var,
			Tmcd,
			Tmch,
			Tmci,
			Tmcm,
			Tmcs,
			Tmfm,
			Tmt,
			Tmtd,
			Tmth,
			Tmti,
			Tmtm,
			Tmts                                                                                                            );
		public static readonly Opcode Tryc             = new(0x90, &Opcode.Functions.Tryc,    "tryc <label>"                );
		public static readonly Opcode Tryf             = new(0xA0, &Opcode.Functions.Tryf,    "tryf <label>, <label2>"      );
		public static readonly Opcode Tryn             = new(0xD3, &Opcode.Functions.Tryn,    "tryn <label>"                );
		public static readonly Opcode Tsa              = new(0x59, &Opcode.Functions.Tsa,     "tsa"                         );
		public static readonly Opcode Txa              = new(0x53, &Opcode.Functions.Txa,     "txa"                         );
		public static readonly Opcode Txy              = new(0x54, &Opcode.Functions.Txy,     "txy"                         );
		public static readonly Opcode Tya              = new(0x55, &Opcode.Functions.Tya,     "tya"                         );
		public static readonly Opcode Type             = new(0x72, &Opcode.Functions.Type_fn, "type"                        );
		public static readonly Opcode Tyx              = new(0x56, &Opcode.Functions.Tyx,     "tyx"                         );

		public static readonly Opcode Wait_obj         = new(0xEE, &Opcode.Functions.Wait,    "wait <obj>"                  );
		public static readonly Opcode Wait_var         = new(0xFE, &Opcode.Functions.Wait,    "wait <var>"                  );

		public static readonly Opcode Xor_obj          = new(0x03, &Opcode.Functions.Xor,     "xor <obj>"                   );
		public static readonly Opcode Xor_var          = new(0x23, &Opcode.Functions.Xor,     "xor <var>"                   );
	}
}
