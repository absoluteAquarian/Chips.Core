using System;

namespace Chips.Core.Meta {
	[AttributeUsage(AttributeTargets.Method)]
	public class FunctionSizeAttribute : Attribute {
		public readonly int Size;

		public FunctionSizeAttribute(int size) {
			Size = size;
		}
	}
}
