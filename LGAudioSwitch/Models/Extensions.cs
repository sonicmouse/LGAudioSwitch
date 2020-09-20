using LGAudioSwitch.CoreAudioInternal;
using System.ComponentModel;

namespace LGAudioSwitch.Models
{
	internal static class Extensions
	{
		public static EDataFlow ToDataFlow(this AudioDeviceType type)
		{
			switch (type)
			{
				case AudioDeviceType.All: return EDataFlow.All;
				case AudioDeviceType.Input: return EDataFlow.Capture;
				case AudioDeviceType.Output: return EDataFlow.Render;
			}
			throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(AudioDeviceType));
		}

		public static AudioDeviceType ToAudioDeviceType(this EDataFlow type)
		{
			switch (type)
			{
				case EDataFlow.All: return AudioDeviceType.All;
				case EDataFlow.Capture: return AudioDeviceType.Input;
				case EDataFlow.Render: return AudioDeviceType.Output;
			}
			throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(EDataFlow));
		}
	}
}
