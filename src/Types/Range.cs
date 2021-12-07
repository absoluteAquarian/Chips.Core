namespace Chips.Core.Types{
	public struct Range{
		public readonly int start, end;

		public Range(int start, int end){
			this.start = start;
			this.end = end;

			if(start > end)
				throw new ArgumentException("Range start must be less than or equal to range end", nameof(start));
		}

		public static unsafe explicit operator int[](Range range){
			int stride = range.end - range.start;
			if(stride == 0)
				return Array.Empty<int>();

			int[] ret = new int[stride];
			fixed(int* ptr = ret){
				int* nfPtr = ptr;
				for(int i = 0; i < stride; i++, nfPtr++)
					*nfPtr = range.start + i;
			}

			return ret;
		}

		public override string ToString() => $"[{start}..{end}]";
	}
}
