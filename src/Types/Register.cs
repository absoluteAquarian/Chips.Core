using Chips.Core.Meta;
using Chips.Core.Specifications;
using Chips.Core.Utility;
using System.Numerics;

namespace Chips.Core.Types{
	public unsafe class Register{
		private object? data;
		public object? Data{
			get => getDataOverride is not null ? getDataOverride() : data;
			set{
				if(acceptValueFunc is not null && !acceptValueFunc(value))
					throw new RegisterAssignmentException($"{Formatting.FormatObject(this)} cannot accept values of type \"{TypeTracking.GetChipsType(value)}\"", globalContext);

				data = value;

				Metadata.Registers.CheckRegister(this);
			}
		}

		internal readonly delegate*<object?, bool> acceptValueFunc;

		internal delegate*<object?> getDataOverride;

		public readonly string name;

		internal static Opcode.FunctionContext globalContext;

		internal Register(string name, object? initialValue, delegate*<object?, bool> acceptValueFunc){
			this.name = name;
			Data = initialValue;
			this.acceptValueFunc = acceptValueFunc;
		}

		public void SetValue(ref object? target, object? value)
			=> Data = value;

		public object? GetValue(object? target)
			=> Data;

		public override string ToString() => $"&{name}";
	}
}
