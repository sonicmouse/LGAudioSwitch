using System;

namespace LGAudioSwitch.CoreAudioInternal
{
	internal static class PropertyKeys
	{
		/// <summary>
		/// PKEY _Device_FriendlyName
		/// </summary>
		public static readonly PropertyKey PKEY_DEVICE_FRIENDLY_NAME =
			new PropertyKey(new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), 14);

		/// <summary>
		/// PKEY _Device_Description
		/// </summary>
		public static readonly PropertyKey PKEY_DEVICE_DESCRIPTION =
			new PropertyKey(new Guid(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0), 2);
	}
}