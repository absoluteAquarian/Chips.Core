using Chips.Core.Specifications;
using Chips.Core.Utility;
using System.Numerics;

namespace Chips.Core.Types{
	public unsafe class Register{
		private object? data;
		public object? Data{
			get => data;
			set{
				if(acceptValueFunc is not null && !acceptValueFunc(value))
					throw new RegisterAssignmentException($"{Formatting.FormatObject(this)} cannot accept values of type \"{TypeTracking.GetChipsType(value)}\"", globalContext);

				data = value;
			}
		}

		internal delegate*<object?, bool> acceptValueFunc;

		public readonly string name;

		internal static Opcode.FunctionContext globalContext;

		internal Register(string name, object? initialValue, delegate*<object?, bool> acceptValueFunc){
			this.name = name;
			Data = initialValue;
			this.acceptValueFunc = acceptValueFunc;
		}

		public override string ToString() => $"&{name}";
	}
}
