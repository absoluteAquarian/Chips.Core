using Chips.Core.Meta;
using System;

namespace Chips.Core {
	public static unsafe class Sandbox {
		public const string Version = "1.0";

		public const int IO_HANDLES = 8;

		public static bool AllowStackOverflow;

		public static int Execute(string[] args, int stackSize, bool allowStackOverflow, delegate*<void> entryPoint) {
			//Invoke the static ctors
			_ = Metadata.Registers.A;
			_ = Metadata.Flags.Carry;
			_ = Metadata.stack;

			AllowStackOverflow = allowStackOverflow;
			Metadata.stack = new(stackSize);
			Metadata.programArgs = args;
			Metadata.ioHandles = new IOHandle[IO_HANDLES];

			for (int i = 0; i < IO_HANDLES; i++)
				Metadata.ioHandles[i] = new();

			try {
				entryPoint();
			} catch (Exception ex) {
				if (ex.InnerException != null)
					ex = ex.InnerException;

				Console.WriteLine($"{ex.GetType().Name} thrown: {ex.Message}\nCompiled stacktrace:\n{ex.StackTrace}");
			} finally {
				for (int i = 0; i < IO_HANDLES; i++)
					(Metadata.ioHandles[i].handle as IDisposable)?.Dispose();
			}

			return 0;
		}
	}
}
