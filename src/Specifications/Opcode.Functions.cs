using Chips.Core.Meta;
using Chips.Core.Types;
using Chips.Core.Types.NumberProcessing;
using Chips.Core.Utility;

namespace Chips.Core.Specifications{
	public unsafe partial class Opcode{
		internal static class Functions{
			#region Functions - A
			public static void Abs(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not INumber a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a number value", context);

				Metadata.Registers.A.Data = a.Abs().Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkIntegers: true, checkFloats: true);
			}

			public static void Acos(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Acos() as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkFloats: true);
			}

			public static void Acsh(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Acosh() as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkFloats: true);
			}

			public static void Add(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not INumber a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a number value", context);
				if(ValueConverter.UnboxToUnderlyingType(context.args[0]) is not INumber arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a number value", context);

				Metadata.Registers.A.Data = a.Add(arg).Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkIntegers: true, checkFloats: true);
			}

			public static void Aems(FunctionContext context){
				Metadata.Registers.A.Data = ArithmeticSet.EmptySet;

				CheckZeroFlag(Metadata.Registers.A.Data, checkCollections: true);
			}

			public static void And(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);
				if(ValueConverter.UnboxToUnderlyingType(context.args[0]) is not IInteger arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not an integer", context);

				Metadata.Registers.A.Data = (a.And(arg) as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkIntegers: true);
			}

			public static void Art(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);
				if(ValueConverter.UnboxToUnderlyingType(context.args[0]) is not IFloat arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a floating-point number", context);

				Metadata.Registers.A.Data = (a.Root(arg) as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkFloats: true);
			}

			public static void Asin(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Asin() as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkFloats: true);
			}

			public static void Asl(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);

				Metadata.Registers.A.Data = (a.ArithmeticShiftLeft() as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkIntegers: true);
			}

			public static void Asnh(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Asinh() as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkFloats: true);
			}

			public static void Asr(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);

				Metadata.Registers.A.Data = (a.ArithmeticShiftRight() as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkIntegers: true);
			}

			public static void Atan(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Atan() as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkFloats: true);
			}

			public static void Atnh(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);

				Metadata.Registers.A.Data = (a.Atanh() as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkFloats: true);
			}

			public static void Atnt(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IFloat a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not a floating-point number value", context);
				if(ValueConverter.UnboxToUnderlyingType(context.args[0]) is not IFloat arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not a floating-point number", context);

				Metadata.Registers.A.Data = (a.Atan2(arg) as INumber)!.Value;

				CheckZeroFlag(Metadata.Registers.A.Data, checkFloats: true);
			}
			#endregion
		}
	}
}
