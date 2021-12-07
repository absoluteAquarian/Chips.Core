using Chips.Core.Meta;
using Chips.Core.Utility;

#pragma warning disable CS0162
namespace Chips.Core.Types.NumberProcessing{
	[TextTemplateGenerated]
	public struct SByte_T : INumber, IInteger{
		private SByte value;

		public object Value => value;

		public SByte_T(SByte value){
			this.value = value;
		}

		public SByte_T(Int32 value){
			this.value = (SByte)value;
		}

		public INumber Add(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(SByte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Add(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(SByte))
				return number.Add(this);

			SByte_T convert = ValueConverter.CastToSByte_T(number);
			return new SByte_T(value + convert.value);
		}

		public IInteger And(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(SByte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-AND operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(SByte))
				return number.And(this);

			SByte_T convert = ValueConverter.CastToSByte_T(iNum);
			return new SByte_T(value & convert.value);
		}

		public IInteger ArithmeticRotateLeft(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = unchecked(value & (SByte)((SByte)1 << (8 * sizeof(SByte) - 1))) != 0;
			
			var i = new SByte_T(value << 1);
			if(carry)
				i.value |= 1;

			return i;
		}

		public IInteger ArithmeticRotateRight(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = (value & 1) != 0;
			
			var i = new SByte_T(value >> 1);
			if(carry)
				i.value = (SByte)unchecked(i.value | ((SByte)1 << (8 * sizeof(SByte) - 1)));

			return i;
		}

		public IInteger ArithmeticShiftLeft()
			=> new SByte_T(value << 1);

		public IInteger ArithmeticShiftRight()
			=> new SByte_T(value >> 1);

		public INumber Divide(INumber number, bool inverseLogic = false){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(SByte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Divide(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(SByte))
				return number.Divide(this, true);

			SByte_T convert = ValueConverter.CastToSByte_T(number);
			return new SByte_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBit(byte bit){
			if(bit >= 8 * sizeof(SByte))
				return new SByte_T(0);
			
			SByte mask = (SByte)(1 << bit);
			return new SByte_T(value & mask);
		}

		public INumber Multiply(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(SByte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Multiply(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(SByte))
				return number.Multiply(this);

			SByte_T convert = ValueConverter.CastToSByte_T(number);
			return new SByte_T(unchecked(value * convert.value));
		}

		public INumber Negate(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(SByte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Negate();
			}

			return new SByte_T(-value);
		}

		public IInteger Not(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(SByte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.Not();
			}

			return new SByte_T(~value);
		}

		public IInteger Or(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(SByte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-OR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(SByte))
				return number.And(this);

			SByte_T convert = ValueConverter.CastToSByte_T(iNum);
			return new SByte_T(value | convert.value);
		}

		public INumber Remainder(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(SByte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Remainder(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(SByte))
				return number.Remainder(this);

			SByte_T convert = ValueConverter.CastToSByte_T(number);
			return new SByte_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(SByte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Subtract(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(SByte))
				return number.Negate().Multiply(this.Negate());

			SByte_T convert = ValueConverter.CastToSByte_T(number);
			return new SByte_T(unchecked(value - convert.value));
		}

		public IInteger Xor(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(SByte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-XOR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(SByte))
				return number.And(this);

			SByte_T convert = ValueConverter.CastToSByte_T(iNum);
			return new SByte_T(value ^ convert.value);
		}
	}

	[TextTemplateGenerated]
	public struct Int16_T : INumber, IInteger{
		private Int16 value;

		public object Value => value;

		public Int16_T(Int16 value){
			this.value = value;
		}

		public Int16_T(Int32 value){
			this.value = (Int16)value;
		}

		public INumber Add(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Add(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int16))
				return number.Add(this);

			Int16_T convert = ValueConverter.CastToInt16_T(number);
			return new Int16_T(value + convert.value);
		}

		public IInteger And(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-AND operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Int16))
				return number.And(this);

			Int16_T convert = ValueConverter.CastToInt16_T(iNum);
			return new Int16_T(value & convert.value);
		}

		public IInteger ArithmeticRotateLeft(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = unchecked(value & (Int16)((Int16)1 << (8 * sizeof(Int16) - 1))) != 0;
			
			var i = new Int16_T(value << 1);
			if(carry)
				i.value |= 1;

			return i;
		}

		public IInteger ArithmeticRotateRight(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = (value & 1) != 0;
			
			var i = new Int16_T(value >> 1);
			if(carry)
				i.value = (Int16)unchecked(i.value | ((Int16)1 << (8 * sizeof(Int16) - 1)));

			return i;
		}

		public IInteger ArithmeticShiftLeft()
			=> new Int16_T(value << 1);

		public IInteger ArithmeticShiftRight()
			=> new Int16_T(value >> 1);

		public INumber Divide(INumber number, bool inverseLogic = false){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Divide(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int16))
				return number.Divide(this, true);

			Int16_T convert = ValueConverter.CastToInt16_T(number);
			return new Int16_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBit(byte bit){
			if(bit >= 8 * sizeof(Int16))
				return new Int16_T(0);
			
			Int16 mask = (Int16)(1 << bit);
			return new Int16_T(value & mask);
		}

		public INumber Multiply(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Multiply(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int16))
				return number.Multiply(this);

			Int16_T convert = ValueConverter.CastToInt16_T(number);
			return new Int16_T(unchecked(value * convert.value));
		}

		public INumber Negate(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Negate();
			}

			return new Int16_T(-value);
		}

		public IInteger Not(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.Not();
			}

			return new Int16_T(~value);
		}

		public IInteger Or(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-OR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Int16))
				return number.And(this);

			Int16_T convert = ValueConverter.CastToInt16_T(iNum);
			return new Int16_T(value | convert.value);
		}

		public INumber Remainder(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Remainder(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int16))
				return number.Remainder(this);

			Int16_T convert = ValueConverter.CastToInt16_T(number);
			return new Int16_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Subtract(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int16))
				return number.Negate().Multiply(this.Negate());

			Int16_T convert = ValueConverter.CastToInt16_T(number);
			return new Int16_T(unchecked(value - convert.value));
		}

		public IInteger Xor(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-XOR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Int16))
				return number.And(this);

			Int16_T convert = ValueConverter.CastToInt16_T(iNum);
			return new Int16_T(value ^ convert.value);
		}
	}

	[TextTemplateGenerated]
	public struct Int32_T : INumber, IInteger{
		private Int32 value;

		public object Value => value;

		public Int32_T(Int32 value){
			this.value = value;
		}


		public INumber Add(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Add(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int32))
				return number.Add(this);

			Int32_T convert = ValueConverter.CastToInt32_T(number);
			return new Int32_T(value + convert.value);
		}

		public IInteger And(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-AND operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Int32))
				return number.And(this);

			Int32_T convert = ValueConverter.CastToInt32_T(iNum);
			return new Int32_T(value & convert.value);
		}

		public IInteger ArithmeticRotateLeft(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = unchecked(value & (Int32)((Int32)1 << (8 * sizeof(Int32) - 1))) != 0;
			
			var i = new Int32_T(value << 1);
			if(carry)
				i.value |= 1;

			return i;
		}

		public IInteger ArithmeticRotateRight(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = (value & 1) != 0;
			
			var i = new Int32_T(value >> 1);
			if(carry)
				i.value = (Int32)unchecked(i.value | ((Int32)1 << (8 * sizeof(Int32) - 1)));

			return i;
		}

		public IInteger ArithmeticShiftLeft()
			=> new Int32_T(value << 1);

		public IInteger ArithmeticShiftRight()
			=> new Int32_T(value >> 1);

		public INumber Divide(INumber number, bool inverseLogic = false){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Divide(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int32))
				return number.Divide(this, true);

			Int32_T convert = ValueConverter.CastToInt32_T(number);
			return new Int32_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBit(byte bit){
			if(bit >= 8 * sizeof(Int32))
				return new Int32_T(0);
			
			Int32 mask = (Int32)(1 << bit);
			return new Int32_T(value & mask);
		}

		public INumber Multiply(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Multiply(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int32))
				return number.Multiply(this);

			Int32_T convert = ValueConverter.CastToInt32_T(number);
			return new Int32_T(unchecked(value * convert.value));
		}

		public INumber Negate(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Negate();
			}

			return new Int32_T(-value);
		}

		public IInteger Not(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.Not();
			}

			return new Int32_T(~value);
		}

		public IInteger Or(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-OR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Int32))
				return number.And(this);

			Int32_T convert = ValueConverter.CastToInt32_T(iNum);
			return new Int32_T(value | convert.value);
		}

		public INumber Remainder(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Remainder(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int32))
				return number.Remainder(this);

			Int32_T convert = ValueConverter.CastToInt32_T(number);
			return new Int32_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Subtract(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int32))
				return number.Negate().Multiply(this.Negate());

			Int32_T convert = ValueConverter.CastToInt32_T(number);
			return new Int32_T(unchecked(value - convert.value));
		}

		public IInteger Xor(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-XOR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Int32))
				return number.And(this);

			Int32_T convert = ValueConverter.CastToInt32_T(iNum);
			return new Int32_T(value ^ convert.value);
		}
	}

	[TextTemplateGenerated]
	public struct Int64_T : INumber, IInteger{
		private Int64 value;

		public object Value => value;

		public Int64_T(Int64 value){
			this.value = value;
		}

		public Int64_T(Int32 value){
			this.value = (Int64)value;
		}

		public INumber Add(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Add(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int64))
				return number.Add(this);

			Int64_T convert = ValueConverter.CastToInt64_T(number);
			return new Int64_T(value + convert.value);
		}

		public IInteger And(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-AND operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Int64))
				return number.And(this);

			Int64_T convert = ValueConverter.CastToInt64_T(iNum);
			return new Int64_T(value & convert.value);
		}

		public IInteger ArithmeticRotateLeft(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = unchecked(value & (Int64)((Int64)1 << (8 * sizeof(Int64) - 1))) != 0;
			
			var i = new Int64_T(value << 1);
			if(carry)
				i.value |= 1;

			return i;
		}

		public IInteger ArithmeticRotateRight(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = (value & 1) != 0;
			
			var i = new Int64_T(value >> 1);
			if(carry)
				i.value = (Int64)unchecked(i.value | ((Int64)1 << (8 * sizeof(Int64) - 1)));

			return i;
		}

		public IInteger ArithmeticShiftLeft()
			=> new Int64_T(value << 1);

		public IInteger ArithmeticShiftRight()
			=> new Int64_T(value >> 1);

		public INumber Divide(INumber number, bool inverseLogic = false){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Divide(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int64))
				return number.Divide(this, true);

			Int64_T convert = ValueConverter.CastToInt64_T(number);
			return new Int64_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBit(byte bit){
			if(bit >= 8 * sizeof(Int64))
				return new Int64_T(0);
			
			Int64 mask = (Int64)(1 << bit);
			return new Int64_T(value & mask);
		}

		public INumber Multiply(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Multiply(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int64))
				return number.Multiply(this);

			Int64_T convert = ValueConverter.CastToInt64_T(number);
			return new Int64_T(unchecked(value * convert.value));
		}

		public INumber Negate(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Negate();
			}

			return new Int64_T(-value);
		}

		public IInteger Not(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.Not();
			}

			return new Int64_T(~value);
		}

		public IInteger Or(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-OR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Int64))
				return number.And(this);

			Int64_T convert = ValueConverter.CastToInt64_T(iNum);
			return new Int64_T(value | convert.value);
		}

		public INumber Remainder(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Remainder(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int64))
				return number.Remainder(this);

			Int64_T convert = ValueConverter.CastToInt64_T(number);
			return new Int64_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Subtract(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Int64))
				return number.Negate().Multiply(this.Negate());

			Int64_T convert = ValueConverter.CastToInt64_T(number);
			return new Int64_T(unchecked(value - convert.value));
		}

		public IInteger Xor(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Int64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-XOR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Int64))
				return number.And(this);

			Int64_T convert = ValueConverter.CastToInt64_T(iNum);
			return new Int64_T(value ^ convert.value);
		}
	}

	[TextTemplateGenerated]
	public struct Byte_T : INumber, IInteger{
		private Byte value;

		public object Value => value;

		public Byte_T(Byte value){
			this.value = value;
		}

		public Byte_T(Int32 value){
			this.value = (Byte)value;
		}

		public INumber Add(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Byte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Add(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Byte))
				return number.Add(this);

			Byte_T convert = ValueConverter.CastToByte_T(number);
			return new Byte_T(value + convert.value);
		}

		public IInteger And(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Byte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-AND operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Byte))
				return number.And(this);

			Byte_T convert = ValueConverter.CastToByte_T(iNum);
			return new Byte_T(value & convert.value);
		}

		public IInteger ArithmeticRotateLeft(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = unchecked(value & (Byte)((Byte)1 << (8 * sizeof(Byte) - 1))) != 0;
			
			var i = new Byte_T(value << 1);
			if(carry)
				i.value |= 1;

			return i;
		}

		public IInteger ArithmeticRotateRight(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = (value & 1) != 0;
			
			var i = new Byte_T(value >> 1);
			if(carry)
				i.value = (Byte)unchecked(i.value | ((Byte)1 << (8 * sizeof(Byte) - 1)));

			return i;
		}

		public IInteger ArithmeticShiftLeft()
			=> new Byte_T(value << 1);

		public IInteger ArithmeticShiftRight()
			=> new Byte_T(value >> 1);

		public INumber Divide(INumber number, bool inverseLogic = false){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Byte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Divide(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Byte))
				return number.Divide(this, true);

			Byte_T convert = ValueConverter.CastToByte_T(number);
			return new Byte_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBit(byte bit){
			if(bit >= 8 * sizeof(Byte))
				return new Byte_T(0);
			
			Byte mask = (Byte)(1 << bit);
			return new Byte_T(value & mask);
		}

		public INumber Multiply(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Byte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Multiply(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Byte))
				return number.Multiply(this);

			Byte_T convert = ValueConverter.CastToByte_T(number);
			return new Byte_T(unchecked(value * convert.value));
		}

		public INumber Negate(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Byte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Negate();
			}

			return new Byte_T(-value);
		}

		public IInteger Not(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Byte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.Not();
			}

			return new Byte_T(~value);
		}

		public IInteger Or(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Byte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-OR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Byte))
				return number.And(this);

			Byte_T convert = ValueConverter.CastToByte_T(iNum);
			return new Byte_T(value | convert.value);
		}

		public INumber Remainder(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Byte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Remainder(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Byte))
				return number.Remainder(this);

			Byte_T convert = ValueConverter.CastToByte_T(number);
			return new Byte_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Byte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Subtract(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(Byte))
				return number.Negate().Multiply(this.Negate());

			Byte_T convert = ValueConverter.CastToByte_T(number);
			return new Byte_T(unchecked(value - convert.value));
		}

		public IInteger Xor(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(Byte) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-XOR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(Byte))
				return number.And(this);

			Byte_T convert = ValueConverter.CastToByte_T(iNum);
			return new Byte_T(value ^ convert.value);
		}
	}

	[TextTemplateGenerated]
	public struct UInt16_T : INumber, IInteger{
		private UInt16 value;

		public object Value => value;

		public UInt16_T(UInt16 value){
			this.value = value;
		}

		public UInt16_T(Int32 value){
			this.value = (UInt16)value;
		}

		public INumber Add(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Add(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt16))
				return number.Add(this);

			UInt16_T convert = ValueConverter.CastToUInt16_T(number);
			return new UInt16_T(value + convert.value);
		}

		public IInteger And(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-AND operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(UInt16))
				return number.And(this);

			UInt16_T convert = ValueConverter.CastToUInt16_T(iNum);
			return new UInt16_T(value & convert.value);
		}

		public IInteger ArithmeticRotateLeft(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = unchecked(value & (UInt16)((UInt16)1 << (8 * sizeof(UInt16) - 1))) != 0;
			
			var i = new UInt16_T(value << 1);
			if(carry)
				i.value |= 1;

			return i;
		}

		public IInteger ArithmeticRotateRight(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = (value & 1) != 0;
			
			var i = new UInt16_T(value >> 1);
			if(carry)
				i.value = (UInt16)unchecked(i.value | ((UInt16)1 << (8 * sizeof(UInt16) - 1)));

			return i;
		}

		public IInteger ArithmeticShiftLeft()
			=> new UInt16_T(value << 1);

		public IInteger ArithmeticShiftRight()
			=> new UInt16_T(value >> 1);

		public INumber Divide(INumber number, bool inverseLogic = false){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Divide(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt16))
				return number.Divide(this, true);

			UInt16_T convert = ValueConverter.CastToUInt16_T(number);
			return new UInt16_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBit(byte bit){
			if(bit >= 8 * sizeof(UInt16))
				return new UInt16_T(0);
			
			UInt16 mask = (UInt16)(1 << bit);
			return new UInt16_T(value & mask);
		}

		public INumber Multiply(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Multiply(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt16))
				return number.Multiply(this);

			UInt16_T convert = ValueConverter.CastToUInt16_T(number);
			return new UInt16_T(unchecked(value * convert.value));
		}

		public INumber Negate(){
			throw new InvalidOperationException("Negation cannot be performed on unsigned integers");
		}

		public IInteger Not(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.Not();
			}

			return new UInt16_T(~value);
		}

		public IInteger Or(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-OR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(UInt16))
				return number.And(this);

			UInt16_T convert = ValueConverter.CastToUInt16_T(iNum);
			return new UInt16_T(value | convert.value);
		}

		public INumber Remainder(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Remainder(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt16))
				return number.Remainder(this);

			UInt16_T convert = ValueConverter.CastToUInt16_T(number);
			return new UInt16_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Subtract(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt16))
				return number.Negate().Multiply(this.Negate());

			UInt16_T convert = ValueConverter.CastToUInt16_T(number);
			return new UInt16_T(unchecked(value - convert.value));
		}

		public IInteger Xor(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt16) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-XOR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(UInt16))
				return number.And(this);

			UInt16_T convert = ValueConverter.CastToUInt16_T(iNum);
			return new UInt16_T(value ^ convert.value);
		}
	}

	[TextTemplateGenerated]
	public struct UInt32_T : INumber, IInteger{
		private UInt32 value;

		public object Value => value;

		public UInt32_T(UInt32 value){
			this.value = value;
		}

		public UInt32_T(Int32 value){
			this.value = (UInt32)value;
		}

		public INumber Add(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Add(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt32))
				return number.Add(this);

			UInt32_T convert = ValueConverter.CastToUInt32_T(number);
			return new UInt32_T(value + convert.value);
		}

		public IInteger And(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-AND operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(UInt32))
				return number.And(this);

			UInt32_T convert = ValueConverter.CastToUInt32_T(iNum);
			return new UInt32_T(value & convert.value);
		}

		public IInteger ArithmeticRotateLeft(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = unchecked(value & (UInt32)((UInt32)1 << (8 * sizeof(UInt32) - 1))) != 0;
			
			var i = new UInt32_T(value << 1);
			if(carry)
				i.value |= 1;

			return i;
		}

		public IInteger ArithmeticRotateRight(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = (value & 1) != 0;
			
			var i = new UInt32_T(value >> 1);
			if(carry)
				i.value = (UInt32)unchecked(i.value | ((UInt32)1 << (8 * sizeof(UInt32) - 1)));

			return i;
		}

		public IInteger ArithmeticShiftLeft()
			=> new UInt32_T(value << 1);

		public IInteger ArithmeticShiftRight()
			=> new UInt32_T(value >> 1);

		public INumber Divide(INumber number, bool inverseLogic = false){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Divide(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt32))
				return number.Divide(this, true);

			UInt32_T convert = ValueConverter.CastToUInt32_T(number);
			return new UInt32_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBit(byte bit){
			if(bit >= 8 * sizeof(UInt32))
				return new UInt32_T(0);
			
			UInt32 mask = (UInt32)(1 << bit);
			return new UInt32_T(value & mask);
		}

		public INumber Multiply(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Multiply(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt32))
				return number.Multiply(this);

			UInt32_T convert = ValueConverter.CastToUInt32_T(number);
			return new UInt32_T(unchecked(value * convert.value));
		}

		public INumber Negate(){
			throw new InvalidOperationException("Negation cannot be performed on unsigned integers");
		}

		public IInteger Not(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.Not();
			}

			return new UInt32_T(~value);
		}

		public IInteger Or(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-OR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(UInt32))
				return number.And(this);

			UInt32_T convert = ValueConverter.CastToUInt32_T(iNum);
			return new UInt32_T(value | convert.value);
		}

		public INumber Remainder(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Remainder(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt32))
				return number.Remainder(this);

			UInt32_T convert = ValueConverter.CastToUInt32_T(number);
			return new UInt32_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Subtract(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt32))
				return number.Negate().Multiply(this.Negate());

			UInt32_T convert = ValueConverter.CastToUInt32_T(number);
			return new UInt32_T(unchecked(value - convert.value));
		}

		public IInteger Xor(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt32) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-XOR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(UInt32))
				return number.And(this);

			UInt32_T convert = ValueConverter.CastToUInt32_T(iNum);
			return new UInt32_T(value ^ convert.value);
		}
	}

	[TextTemplateGenerated]
	public struct UInt64_T : INumber, IInteger{
		private UInt64 value;

		public object Value => value;

		public UInt64_T(UInt64 value){
			this.value = value;
		}

		public UInt64_T(Int32 value){
			this.value = (UInt64)value;
		}

		public INumber Add(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Add(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt64))
				return number.Add(this);

			UInt64_T convert = ValueConverter.CastToUInt64_T(number);
			return new UInt64_T(value + convert.value);
		}

		public IInteger And(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-AND operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(UInt64))
				return number.And(this);

			UInt64_T convert = ValueConverter.CastToUInt64_T(iNum);
			return new UInt64_T(value & convert.value);
		}

		public IInteger ArithmeticRotateLeft(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = unchecked(value & (UInt64)((UInt64)1 << (8 * sizeof(UInt64) - 1))) != 0;
			
			var i = new UInt64_T(value << 1);
			if(carry)
				i.value |= 1;

			return i;
		}

		public IInteger ArithmeticRotateRight(){
			bool carry = Metadata.Flags.Carry;
			Metadata.Flags.Carry = (value & 1) != 0;
			
			var i = new UInt64_T(value >> 1);
			if(carry)
				i.value = (UInt64)unchecked(i.value | ((UInt64)1 << (8 * sizeof(UInt64) - 1)));

			return i;
		}

		public IInteger ArithmeticShiftLeft()
			=> new UInt64_T(value << 1);

		public IInteger ArithmeticShiftRight()
			=> new UInt64_T(value >> 1);

		public INumber Divide(INumber number, bool inverseLogic = false){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Divide(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt64))
				return number.Divide(this, true);

			UInt64_T convert = ValueConverter.CastToUInt64_T(number);
			return new UInt64_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBit(byte bit){
			if(bit >= 8 * sizeof(UInt64))
				return new UInt64_T(0);
			
			UInt64 mask = (UInt64)(1 << bit);
			return new UInt64_T(value & mask);
		}

		public INumber Multiply(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Multiply(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt64))
				return number.Multiply(this);

			UInt64_T convert = ValueConverter.CastToUInt64_T(number);
			return new UInt64_T(unchecked(value * convert.value));
		}

		public INumber Negate(){
			throw new InvalidOperationException("Negation cannot be performed on unsigned integers");
		}

		public IInteger Not(){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.Not();
			}

			return new UInt64_T(~value);
		}

		public IInteger Or(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-OR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(UInt64))
				return number.And(this);

			UInt64_T convert = ValueConverter.CastToUInt64_T(iNum);
			return new UInt64_T(value | convert.value);
		}

		public INumber Remainder(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Remainder(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt64))
				return number.Remainder(this);

			UInt64_T convert = ValueConverter.CastToUInt64_T(number);
			return new UInt64_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return upcast.Subtract(number);
			}

			if(TypeTracking.GetSizeFromNumericType(number.Value.GetType()) > sizeof(UInt64))
				return number.Negate().Multiply(this.Negate());

			UInt64_T convert = ValueConverter.CastToUInt64_T(number);
			return new UInt64_T(unchecked(value - convert.value));
		}

		public IInteger Xor(IInteger number){
			//For sizes larger than int, this block should be removed by the compiler
			if(sizeof(UInt64) < sizeof(int)){
				INumber upcast = ValueConverter.UpcastToAtLeastInt32(this);
				return (upcast as IInteger)!.And(number);
			}

			if(number is not INumber iNum)
				throw new Exception("Internal Chips Error: IInteger instance was not an INumber");

			if(number is IFloat)
				throw new Exception("Cannot perform bitwise-XOR operations with non-integer values");

			if(TypeTracking.GetSizeFromNumericType(iNum.Value.GetType()) > sizeof(UInt64))
				return number.And(this);

			UInt64_T convert = ValueConverter.CastToUInt64_T(iNum);
			return new UInt64_T(value ^ convert.value);
		}
	}

	[TextTemplateGenerated]
	public struct Single_T : INumber, IFloat{
		private Single value;

		public object Value => value;

		public Single_T(Single value){
			this.value = value;
		}


		public INumber Add(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Single))
				number = ValueConverter.CastToSingle_T(number);
			else if(targetSize > sizeof(Single))
				return number.Add(this);

			Single_T convert = ValueConverter.CastToSingle_T(number);
			return new Single_T(value + convert.value);
		}

		public INumber Divide(INumber number, bool inverseLogic = false){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Single))
				number = ValueConverter.CastToSingle_T(number);
			else if(targetSize > sizeof(Single))
				return number.Divide(this, true);

			Single_T convert = ValueConverter.CastToSingle_T(number);
			return new Single_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBits()
			=> (ValueConverter.RetrieveFloatingPointBits(this) as IInteger)!;

		public INumber Multiply(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Single))
				number = ValueConverter.CastToSingle_T(number);
			else if(targetSize > sizeof(Single))
				return number.Multiply(this);

			Single_T convert = ValueConverter.CastToSingle_T(number);
			return new Single_T(value * convert.value);
		}

		public INumber Negate()
			=> new Single_T(-value);

		public INumber Remainder(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Single))
				number = ValueConverter.CastToSingle_T(number);
			else if(targetSize > sizeof(Single))
				return number.Remainder(this);

			Single_T convert = ValueConverter.CastToSingle_T(number);
			return new Single_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Single))
				number = ValueConverter.CastToSingle_T(number);
			else if(targetSize > sizeof(Single))
				return number.Negate().Subtract(this.Negate());

			Single_T convert = ValueConverter.CastToSingle_T(number);
			return new Single_T(value - convert.value);
		}
	}
	
	[TextTemplateGenerated]
	public struct Double_T : INumber, IFloat{
		private Double value;

		public object Value => value;

		public Double_T(Double value){
			this.value = value;
		}

		public Double_T(Single value){
			this.value = (Double)value;
		}

		public INumber Add(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Double))
				number = ValueConverter.CastToDouble_T(number);
			else if(targetSize > sizeof(Double))
				return number.Add(this);

			Double_T convert = ValueConverter.CastToDouble_T(number);
			return new Double_T(value + convert.value);
		}

		public INumber Divide(INumber number, bool inverseLogic = false){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Double))
				number = ValueConverter.CastToDouble_T(number);
			else if(targetSize > sizeof(Double))
				return number.Divide(this, true);

			Double_T convert = ValueConverter.CastToDouble_T(number);
			return new Double_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBits()
			=> (ValueConverter.RetrieveFloatingPointBits(this) as IInteger)!;

		public INumber Multiply(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Double))
				number = ValueConverter.CastToDouble_T(number);
			else if(targetSize > sizeof(Double))
				return number.Multiply(this);

			Double_T convert = ValueConverter.CastToDouble_T(number);
			return new Double_T(value * convert.value);
		}

		public INumber Negate()
			=> new Double_T(-value);

		public INumber Remainder(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Double))
				number = ValueConverter.CastToDouble_T(number);
			else if(targetSize > sizeof(Double))
				return number.Remainder(this);

			Double_T convert = ValueConverter.CastToDouble_T(number);
			return new Double_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Double))
				number = ValueConverter.CastToDouble_T(number);
			else if(targetSize > sizeof(Double))
				return number.Negate().Subtract(this.Negate());

			Double_T convert = ValueConverter.CastToDouble_T(number);
			return new Double_T(value - convert.value);
		}
	}
	
	[TextTemplateGenerated]
	public struct Decimal_T : INumber, IFloat{
		private Decimal value;

		public object Value => value;

		public Decimal_T(Decimal value){
			this.value = value;
		}

		public Decimal_T(Single value){
			this.value = (Decimal)value;
		}

		public INumber Add(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Decimal))
				number = ValueConverter.CastToDecimal_T(number);
			else if(targetSize > sizeof(Decimal))
				return number.Add(this);

			Decimal_T convert = ValueConverter.CastToDecimal_T(number);
			return new Decimal_T(value + convert.value);
		}

		public INumber Divide(INumber number, bool inverseLogic = false){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Decimal))
				number = ValueConverter.CastToDecimal_T(number);
			else if(targetSize > sizeof(Decimal))
				return number.Divide(this, true);

			Decimal_T convert = ValueConverter.CastToDecimal_T(number);
			return new Decimal_T(!inverseLogic ? value / convert.value : convert.value / value);
		}

		public IInteger GetBits()
			=> throw new InvalidOperationException("Retrieving the bits on an <f128> instance is not supported");

		public INumber Multiply(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Decimal))
				number = ValueConverter.CastToDecimal_T(number);
			else if(targetSize > sizeof(Decimal))
				return number.Multiply(this);

			Decimal_T convert = ValueConverter.CastToDecimal_T(number);
			return new Decimal_T(value * convert.value);
		}

		public INumber Negate()
			=> new Decimal_T(-value);

		public INumber Remainder(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Decimal))
				number = ValueConverter.CastToDecimal_T(number);
			else if(targetSize > sizeof(Decimal))
				return number.Remainder(this);

			Decimal_T convert = ValueConverter.CastToDecimal_T(number);
			return new Decimal_T(value % convert.value);
		}

		public INumber Subtract(INumber number){
			int targetSize = TypeTracking.GetSizeFromNumericType(number.Value.GetType());

			if(number is IInteger || targetSize < sizeof(Decimal))
				number = ValueConverter.CastToDecimal_T(number);
			else if(targetSize > sizeof(Decimal))
				return number.Negate().Subtract(this.Negate());

			Decimal_T convert = ValueConverter.CastToDecimal_T(number);
			return new Decimal_T(value - convert.value);
		}
	}
	
}