using System;
using System.Runtime.InteropServices;

namespace LGAudioSwitch.CoreAudioInternal
{
	internal static class Win32Native
	{
		[DllImport("ole32.dll")]
		public static extern int PropVariantClear(ref PropVariant pvar);
	}
}