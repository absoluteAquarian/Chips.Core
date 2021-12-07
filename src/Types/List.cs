namespace Chips.Core.Types{
	public class List{
		private object[] values;

		public int Capacity{
			get => values.Length;
			set{
				if(value < 0)
					throw new ArgumentOutOfRangeException(nameof(value), "New capacity was negative");

				if(value != values.Length){
					if(value == 0)
						values = Array.Empty<object>();
					else
						Array.Resize(ref values, value);
				}
			}
		}

		public List(){
			values = Array.Empty<object>();
		}

		public List(int capacity){
			values = new object[capacity];
		}

		public object this[int index]{
			get => values[index];
			set{
				if(index < 0)
					throw new ArgumentOutOfRangeException(nameof(index), "Index was negative");

				if(index >= values.Length)
					throw new ArgumentOutOfRangeException(nameof(index), $"Index ({index}) was equal to or exceeded list capacity ({Capacity})");

				values[index] = value;
			}
		}
	}
}
