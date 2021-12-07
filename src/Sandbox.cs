using Chips.Core.Meta;

namespace Chips.Core{
	public static unsafe class Sandbox{
		public static int Execute(string[] args, int stackSize, delegate*<void> entryPoint){
			//Invoke the static ctor
			_ = Metadata.Registers.A;

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

				string message = ex.ToString();
				//Remove the part saying the name since it's said below
				message = message[(message.IndexOf(":") + 2)..];
				Console.WriteLine($"{ex.GetType().Name} thrown in compiled code:\n   {message}");
			}finally{
				for(int i = 0; i < HANDLES; i++)
					(Metadata.ioHandles[i].handle as IDisposable)?.Dispose();
			}

			return 0;
		}
	}
}
