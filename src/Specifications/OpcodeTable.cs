using Chips.Core.Types;
using System;

namespace Chips.Core.Specifications {
	public class OpcodeTable {
		internal Opcode[] table = new Opcode[256];

		public Opcode this[int index] {
			get {
				if (index < 0 || index > byte.MaxValue)
					throw new ArgumentOutOfRangeException(nameof(index));

				var op = table[index];
				if (op is null)
					throw new UnkownOpcodeException((byte)index);
				return op;
			}
			set => table[index] = value;
		}

		public Opcode this[Opcode opcode] => this[opcode.code];
	}
}
