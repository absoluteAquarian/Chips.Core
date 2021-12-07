using System.Runtime.CompilerServices;

namespace Chips.Core.Types{
	public struct Indexer{
		public readonly int value;

		public Indexer(int value){
			this.value = value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ConvertToInteger(int collectionSize)
			=> value >= 0 ? value : collectionSize + value;

		public override string ToString() => value >= 0 ? value.ToString() : $"^{-value}";
	}
}
