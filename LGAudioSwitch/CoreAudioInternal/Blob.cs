using System;

namespace LGAudioSwitch.CoreAudioInternal
{
	internal struct Blob
	{
		public IntPtr Data;
		public int Length;

		[System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Because I said so")]
		private void FixCS0649()
		{
			Length = 0;
			Data = IntPtr.Zero;
		}
	}
}