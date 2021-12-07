using Chips.Core.Meta;
using Chips.Core.Types;
using Chips.Core.Types.NumberProcessing;
using Chips.Core.Utility;

namespace Chips.Core.Specifications{
	public unsafe partial class Opcode{
		internal static class Functions{
			public static void And(FunctionContext context){
				if(ValueConverter.UnboxToUnderlyingType(Metadata.Registers.A.Data) is not IInteger a)
					throw new InvalidRegisterTypeException(Metadata.Registers.A.ToString() + " was not an integer value", context);
				if(ValueConverter.UnboxToUnderlyingType(context.args[0]) is not IInteger arg)
					throw new InvalidOpcodeArgumentException(0, "Value was not an integer", context);

				Metadata.Registers.A.Data = (a.And(arg) as INumber)!.Value;
			}
		}
	}
}
