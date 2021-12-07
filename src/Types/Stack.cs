using Chips.Core.Utility;

namespace Chips.Core.Types{
	public class Stack{
		private readonly object?[] stack;
		public int sp;
		private readonly int capacity;

		public Stack(){
			capacity = 1000;
			stack = new object?[1000];
			sp = 0;
		}

		public Stack(int capacity){
			if(capacity <= 0)
				throw new ArgumentException("Size was too small. Expected a value greater than zero");

			this.capacity = capacity;
			stack = new object[capacity];
			sp = 0;
		}

		public void Push(object obj){
			if(sp >= capacity)
				throw new Exception("Stack overflow detected. Cannot push more objects to the stack.");

			//Locations are in sync.  Just replace the topmost element
			stack[sp] = obj;
			sp++;
		}

		public object? Pop(){
			if(sp <= 0)
				throw new Exception("Stack underflow detected. Cannot pop more objects from the stack.");

			object? obj = stack[sp - 1];
			stack[sp - 1] = null;
			sp--;

			return obj;
		}

		public object? Peek() => sp == 0 ? throw new Exception("Stack does not contain any values") : stack[sp - 1];

		public override string ToString()
			=> sp == 0
				? "[ <empty> ]"
				: Formatting.FormatArray(stack[0..sp]);
	}
}
