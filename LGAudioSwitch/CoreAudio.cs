using LGAudioSwitch.CoreAudioInternal;
using LGAudioSwitch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace LGAudioSwitch
{
	/// <summary>
	/// Main implementation for LGAudioSwitch
	/// </summary>
	public static class CoreAudio
	{
		#region Private Helpers
		private static AudioDevice CreateAudioDeviceFromMMDevice(IMMDevice device)
		{
			Marshal.ThrowExceptionForHR(device.OpenPropertyStore(StorageAccessMode.Read, out var properties));

			var audioDevice = new AudioDevice();

			if (device is IMMEndpoint endPoint)
			{
				Marshal.ThrowExceptionForHR(endPoint.GetDataFlow(out var flow));
				audioDevice.AudioDeviceType = flow.ToAudioDeviceType();
			}

			Marshal.ThrowExceptionForHR(device.GetId(out var id));
			audioDevice.Id = id;

			var propKey = PropertyKeys.PKEY_DEVICE_DESCRIPTION;
			Marshal.ThrowExceptionForHR(properties.GetValue(ref propKey, out var valueDesc));
			audioDevice.Description = valueDesc.Value as string;
			valueDesc.Clear();

			propKey = PropertyKeys.PKEY_DEVICE_FRIENDLY_NAME;
			Marshal.ThrowExceptionForHR(properties.GetValue(ref propKey, out var valueName));
			audioDevice.FriendlyName = valueName.Value as string;
			valueName.Clear();

			return audioDevice;
		}

		private static AudioDevice GetDefaultAudioEndpoint(AudioDeviceType audioDeviceType)
		{
			if (new MMDeviceEnumeratorComObject() is IMMDeviceEnumerator devEnumerator)
			{
				IMMDevice device;
				if (AudioDeviceType.Input == audioDeviceType)
				{
					Marshal.ThrowExceptionForHR(
						devEnumerator.GetDefaultAudioEndpoint(
							audioDeviceType.ToDataFlow(), ERole.Communications, out device));
				}
				else if (AudioDeviceType.Output == audioDeviceType)
				{
					Marshal.ThrowExceptionForHR(
						devEnumerator.GetDefaultAudioEndpoint(
							audioDeviceType.ToDataFlow(), ERole.Console | ERole.Multimedia, out device));
				}
				else
				{
					throw new InvalidEnumArgumentException(
						nameof(audioDeviceType), (int)audioDeviceType, typeof(AudioDeviceType));
				}
				return CreateAudioDeviceFromMMDevice(device);
			}
			return null;
		}
		#endregion

		/// <summary>
		/// Enumerates the <see cref="AudioDevice"/> objects in the current environment
		/// </summary>
		/// <param name="audioDeviceType">The type of devices to enumerate</param>
		public static IEnumerable<AudioDevice> EnumerateAudioDevices(AudioDeviceType audioDeviceType)
		{
			if ((new MMDeviceEnumeratorComObject() is IMMDeviceEnumerator devEnumerator) &&
				(0 == devEnumerator.EnumAudioEndpoints(
					audioDeviceType.ToDataFlow(), EDeviceState.Active, out var devices)) &&
				(0 == devices.GetCount(out var countDevices)))
			{
				for (var i = 0U; i < countDevices; ++i)
				{
					if (0 == devices.Item(i, out var device))
					{
						yield return CreateAudioDeviceFromMMDevice(device);
					}
				}
			}
		}

		/// <summary>
		/// Gets the default <see cref="AudioDevice"/> for input
		/// </summary>
		public static AudioDevice GetDefaultInputAudioDevice() =>
			GetDefaultAudioEndpoint(AudioDeviceType.Input);

		/// <summary>
		/// Gets the default <see cref="AudioDevice"/> for output
		/// </summary>
		public static AudioDevice GetDefaultOutputAudioDevice() =>
			GetDefaultAudioEndpoint(AudioDeviceType.Output);

		/// <summary>
		/// Sets the default <see cref="AudioDevice"/> for this environement
		/// </summary>
		/// <param name="audioDevice">The <see cref="AudioDevice"/> to set as default</param>
		public static void SetDefaultAudioDevice(AudioDevice audioDevice)
		{
			if (AudioDeviceType.Input == audioDevice.AudioDeviceType)
			{
				PolicyConfig.SetDefaultEndpoint(audioDevice.Id, ERole.Communications);
			}
			else if (AudioDeviceType.Output == audioDevice.AudioDeviceType)
			{
				PolicyConfig.SetDefaultEndpoint(audioDevice.Id, ERole.Console | ERole.Multimedia);
			}
			else
			{
				throw new ArgumentException("Argument doesn't contain a valid device type", nameof(audioDevice));
			}
		}
	}
}
