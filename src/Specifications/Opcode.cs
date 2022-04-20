using Chips.Core.Meta;
using Chips.Core.Types;
using Chips.Core.Utility;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Chips.Core.Specifications {
	public unsafe partial class Opcode {
		public struct FunctionContext {
			public object[] args;

			public readonly string? sourceFile;
			public readonly int sourceLine;

			public static readonly FunctionContext NoContext = new();

			public FunctionContext() {
				args = Array.Empty<object>();
				sourceFile = null;
				sourceLine = -1;
			}

			public FunctionContext(string sourceFile, int sourceLine, params object[] args) {
				this.sourceFile = sourceFile;
				this.sourceLine = sourceLine;
				this.args = args;
			}
		}

		public readonly byte code;
		public readonly string descriptor;

		public readonly byte operandCount;

		public readonly bool hasSmallBodyDefinition;

		public readonly OpcodeClassification classification;

		public bool IsParent => table is not null;
		public bool HasParent => Parent is not null && Parent.IsParent && Parent.table![code] == this;

		public readonly OpcodeTable? table;
		public Opcode? Parent { get; private set; }

		internal readonly delegate*<FunctionContext, void> func;

		public delegate void SetValueIndirectly(ref object? target, object? value);
		public delegate object? GetValueIndirectly(object? target);

		public Opcode(byte code, delegate*<FunctionContext, void> func, string descriptor, byte operandCount, bool hasSmallBodyDefinition, OpcodeClassification classification, params Opcode[] derivedCodes) {
			this.code = code;
			this.descriptor = descriptor;
			this.operandCount = operandCount;
			this.hasSmallBodyDefinition = hasSmallBodyDefinition;
			this.classification = classification;
			this.func = func;

			if (derivedCodes is not null && derivedCodes.Length > 0) {
				table = new();

				foreach (var subCode in derivedCodes) {
					table.table[subCode.code] = subCode;
					subCode.Parent = this;
				}
			}
		}

		public void Invoke(FunctionContext context) {
			if (IsParent)
				throw new InvalidOperationException("Internal Chips Error: Attempted to invoke an opcode type with sub-types defined"
					+ ExceptionHelper.GetContextString(context));

			Register.globalContext = context;
			func(context);
		}

		internal static bool ValueIsValidForIOStreamHandle(object? obj, out int handle) {
			handle = -1;

			if (ValueConverter.AsSignedInteger(obj) is long l && l >= 0 && l < Sandbox.IO_HANDLES)
				handle = (int)l;
			else if (ValueConverter.AsUnsignedInteger(obj) is ulong ul && ul < Sandbox.IO_HANDLES)
				handle = (int)ul;

			return handle > -1;
		}
	}
}
