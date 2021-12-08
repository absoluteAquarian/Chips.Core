using Chips.Core.Specifications;

namespace Chips.Core.Types{
	public class RegisterAssignmentException : Exception{
		public RegisterAssignmentException(string message, Opcode.FunctionContext context) : base(message + $"\n  in \"{context.sourceFile}\" on line {context.sourceLine}"){ }
	}

	public class InvalidRegisterTypeException : Exception{
		public InvalidRegisterTypeException(string message, Opcode.FunctionContext context) : base(message + $"\n  in \"{context.sourceFile}\" on line {context.sourceLine}"){ }
	}

	public class InvalidOpcodeArgumentException : Exception{
		public InvalidOpcodeArgumentException(int argument, string reason, Opcode.FunctionContext context) : base($"Argument {argument} was invalid." +
			$"\nReason: {reason}" +
			(!string.IsNullOrEmpty(context.sourceFile) && context.sourceLine >= 0
				? $"\n  in \"{context.sourceFile}\" on line {context.sourceLine}"
				: "")){ }
	}
}
