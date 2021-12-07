using Chips.Core.Types;
using Chips.Core.Utility;

namespace Chips.Core.Meta{
	internal static unsafe class Metadata{
		public static class Registers{
			/// <summary>
			/// The register for arithmetic.  Can contain any type of value
			/// </summary>
			public static Register A = new("A", null, null);
			/// <summary>
			/// The register for storing the current exception
			/// </summary>
			public static Register E = new("E", null, null);
			/// <summary>
			/// The register for indexing.  Can only contain integers
			/// </summary>
			public static Register X = new("X", 0, &TypeTracking.IsInteger);
			/// <summary>
			/// The register for counting.  Can only contain integers
			/// </summary>
			public static Register Y = new("Y", 0, &TypeTracking.IsInteger);
			/// <summary>
			/// The register for string manipulation.  Can only contain strings
			/// </summary>
			public static Register S = new("S", null, &TypeTracking.IsString);
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
			/// Flag $N - value conversion success
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
	}
}
