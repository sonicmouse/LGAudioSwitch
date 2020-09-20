using System;

namespace LGAudioSwitch.CoreAudioInternal
{
	[Flags]
	internal enum EDataFlow
	{
		Render,
		Capture,
		All
	};
}