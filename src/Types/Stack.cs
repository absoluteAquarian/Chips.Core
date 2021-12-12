using Chips.Core.Meta;
using Chips.Core.Utility;

namespace Chips.Core.Types{
	public class Stack{
		private readonly object?[] stack;

		public int SP{ get; private set; }
		
		private readonly int capacity;

		public Stack(){
			capacity = 1000;
			stack = new object?[1000];
			SP = 0;
		}

		public Stack(int capacity){
			if(capacity <= 0)
				throw new ArgumentException("Size was too small. Expected a value greater than zero");

			this.capacity = capacity;
			stack = new object[capacity];
			SP = 0;
		}

		public void Push(object? obj){
			if(SP >= capacity)
				throw new Exception("Stack overflow detected. Cannot push more objects to the stack.");

			stack[SP] = obj;
			SP++;
		}

		public object? Pop(){
			if(SP <= 0)
				throw new Exception("Stack underflow detected. Cannot pop more objects from the stack.");

			object? obj = stack[SP - 1];
			stack[SP - 1] = null;
			SP--;

			return obj;
		}

		public object? Peek() => SP == 0 ? throw new Exception("Stack does not contain any values") : stack[SP - 1];

		public override string ToString()
			=> SP == 0
				? "[ <empty> ]"
				: Formatting.FormatArray(stack[0..SP]);
	}
}
