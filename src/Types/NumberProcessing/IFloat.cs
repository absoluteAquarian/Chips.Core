namespace Chips.Core.Types.NumberProcessing {
	public interface IFloat {
		IFloat Acos();

		IFloat Acosh();

		IFloat Asin();

		IFloat Asinh();

		IFloat Atan();

		IFloat Atan2(IFloat divisor, bool inverseLogic = false);

		IFloat Atanh();

		INumber Ceiling();

		IFloat Cos();

		IFloat Cosh();

		IFloat Exp();

		INumber Floor();

		IInteger GetBits();

		IFloat Inverse();

		IFloat Ln();

		IFloat Log10();

		IFloat Log2();

		IFloat Pow(IFloat exponent);

		IFloat Root(IFloat root);

		IFloat Sin();

		IFloat Sinh();

		IFloat Sqrt();

		IFloat Tan();

		IFloat Tanh();
	}
}
