using Chips.Core.Specifications;
using Chips.Core.Types;
using Chips.Core.Utility;
using System.Reflection;

namespace Chips.Core.Meta{
	internal static unsafe class Metadata{
		public static class Registers{
			/// <summary>
			/// The register for arithmetic.  Can contain any type of value
			/// </summary>
			public static Register A =  new("A", null, null);
			/// <summary>
			/// The register for storing the current exception
			/// </summary>
			public static Register E =  new("E", null, null);
			/// <summary>
			/// The register for indexing.  Can only contain integers
			/// </summary>
			public static Register X =  new("X",    0, &TypeTracking.IsInteger);
			/// <summary>
			/// The register for counting.  Can only contain integers
			/// </summary>
			public static Register Y =  new("Y",    0, &TypeTracking.IsInteger);
			public static Register SP = new("SP",   0, &StackPointer_ReadOnly){ getDataOverride = &StackPointer_GetValue };
			/// <summary>
			/// The register for string manipulation.  Can only contain strings
			/// </summary>
			public static Register S =  new("S", null, &TypeTracking.IsString);

			private static bool StackPointer_ReadOnly(object? obj)
				=> throw new InvalidOperationException("Stack pointer cannot be written to");

			private static object? StackPointer_GetValue()
				=> stack!.SP;
		}

		public static class Flags{
			private static ushort flags;

			/// <summary>
			/// Flag $C - carry bit
			/// </summary>
			public static bool Carry{
				get => (flags & 0x0001) != 0;
				set => flags = (byte)(value ? flags | 0x0001 : flags & ~0x0001);
			}

			/// <summary>
			/// Flag $N - whether value conversion from a string to some other type was successful
			/// </summary>
			public static bool Conversion{
				get => (flags & 0x0002) != 0;
				set => flags = (byte)(value ? flags | 0x0002 : flags & ~0x0002);
			}

			/// <summary>
			/// Flag $O - value comparison
			/// </summary>
			public static bool Comparison{
				get => (flags & 0x0004) != 0;
				set => flags = (byte)(value ? flags | 0x0004 : flags & ~0x0004);
			}

			/// <summary>
			/// Flag $P - toggles the effect of various instructions from value access to value assignment
			/// </summary>
			public static bool PropertyAccess{
				get => (flags & 0x0008) != 0;
				set => flags = (byte)(value ? flags | 0x0008 : flags & ~0x0008);
			}

			/// <summary>
			/// Flag $R - set when a match is found for a Regex instance
			/// </summary>
			public static bool RegexSuccess{
				get => (flags & 0x0010) != 0;
				set => flags = (byte)(value ? flags | 0x0010 : flags & ~0x0010);
			}

			/// <summary>
			/// Flag $Z - set when certain operations result in a zero value
			/// </summary>
			public static bool Zero{
				get => (flags & 0x0020) != 0;
				set => flags = (byte)(value ? flags | 0x0020 : flags & ~0x0020);
			}
		}

		public static Stack? stack;

		public static string[]? programArgs;

		internal static IOHandle[]? ioHandles;

		//Used to ensure that no opcode shares the same code
		internal static readonly OpcodeTable? op;

		static Metadata(){
			op = new OpcodeTable();
			
			foreach(var field in typeof(Opcodes).GetFields(BindingFlags.Public | BindingFlags.Static).Where(f => f.FieldType == typeof(Opcode))){
				Opcode opcode = (field.GetValue(null) as Opcode)!;

				if(opcode.parent?.table is null && op[opcode.code] is not null)
					throw new Exception($"Opcode 0x{opcode.code :X2} cannot be assigned to the instruction \"{opcode.descriptor}\" since it already assigned to the instruction \"{op[opcode.code].descriptor}\"");

				if(opcode.parent?.table is not null && opcode.parent.table[opcode.code] is not null)
					throw new Exception($"Opcode 0x{opcode.parent.code :X2}{opcode.code :X2} cannot be assigned to the instruction \"{opcode.descriptor}\" since it already assigned to the instruction \"{opcode.parent.table[opcode.code].descriptor}\"");

				var table = opcode.parent?.table ?? op;
				table[opcode.code] = opcode;
			}
		}
	}
}
