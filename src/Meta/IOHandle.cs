namespace Chips.Core.Meta{
	internal class IOHandle{
		public FileMode mode;
		public string? file;
		public object? handle;

		private byte settings;

		public bool BinaryModeActive{
			get => (settings & 0x01) != 0;
			set => settings = (byte)(value ? settings | 0x01 : settings & ~0x01);
		}

		public bool WriteNewlines{
			get => (settings & 0x02) != 0;
			set => settings = (byte)(value ? settings | 0x02 : settings & ~0x02);
		}

		public bool WriteToStream{
			get => (settings & 0x04) != 0;
			set => settings = (byte)(value ? settings | 0x04 : settings & ~0x04);
		}

		public bool HandleIsActive{
			get => (settings & 0x08) != 0;
			set => settings = (byte)(value ? settings | 0x08 : settings & ~0x08);
		}
	}
}
