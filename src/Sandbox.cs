using Chips.Core.Meta;

namespace Chips.Core{
	public static unsafe class Sandbox{
		public static int Execute(string[] args, int stackSize, delegate*<void> entryPoint){
			//Invoke the static ctors
			_ = Metadata.Registers.A;
			_ = Metadata.Flags.Carry;
			_ = Metadata.stack;

			const int HANDLES = 8;

			Metadata.stack = new(stackSize);
			Metadata.programArgs = args;
			Metadata.ioHandles = new IOHandle[HANDLES];

			for(int i = 0; i < HANDLES; i++)
				Metadata.ioHandles[i] = new();

			try{
				entryPoint();
			}catch(Exception ex){
				if(ex.InnerException != null)
					ex = ex.InnerException;

				Console.WriteLine($"{ex.GetType().Name} thrown: {ex.Message}\nCompiled stacktrace:\n{ex.StackTrace}");
			}finally{
				for(int i = 0; i < HANDLES; i++)
					(Metadata.ioHandles[i].handle as IDisposable)?.Dispose();
			}

			return 0;
		}
	}
}
