namespace Chips.Core.Types.NumberProcessing {
	public interface INumber {
		object Value { get; }

		INumber Abs();

		INumber Add(INumber number);

		INumber Decrement();

		INumber Divide(INumber number, bool inverseLogic = false);

		INumber Increment();

		INumber Multiply(INumber number);

		INumber Negate();

		INumber Remainder(INumber number);

		INumber Subtract(INumber number);
	}
}
