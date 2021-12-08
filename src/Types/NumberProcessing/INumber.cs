namespace Chips.Core.Types.NumberProcessing{
	public interface INumber{
		object Value{ get; }

		INumber Abs();

		INumber Add(INumber number);

		INumber Divide(INumber number, bool inverseLogic = false);

		INumber Multiply(INumber number);

		INumber Negate();

		INumber Remainder(INumber number);

		INumber Subtract(INumber number);
	}
}
