namespace Chips.Core.Types.NumberProcessing{
	public interface IInteger{
		IInteger And(IInteger number);

		IInteger ArithmeticShiftLeft();

		IInteger ArithmeticShiftRight();

		IInteger ArithmeticRotateLeft();

		IInteger ArithmeticRotateRight();

		IInteger GetBit(byte bit);

		IInteger Not();

		IInteger Or(IInteger number);

		IInteger Xor(IInteger number);
	}
}
