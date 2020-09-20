
# LGAudioSwitch
.NET Standard 2.0/.NET Framework library which utilizes the `IPolicyConfig` interface to switch input/output audio devices on Win7/8/10.

This source was taken from [this repo](https://github.com/cdhunt/AudioSwitcher) and rearranged/simplified to only allow for switching input and output devices.

**Example of enumerating devices:**

	var defInput = CoreAudio.GetDefaultInputAudioDevice();
	var defOutput = CoreAudio.GetDefaultOutputAudioDevice();

	Console.WriteLine("Input devices:");
	foreach (var dev in CoreAudio.
		EnumerateAudioDevices(AudioDeviceType.Input))
	{
		Console.WriteLine(
			$"\t{dev}{(dev.Equals(defInput) ? " [Default]" : string.Empty)}");
	}

	Console.WriteLine("Output devices:");
	foreach (var dev in CoreAudio.
		EnumerateAudioDevices(AudioDeviceType.Output))
	{
		Console.WriteLine(
			$"\t{dev}{(dev.Equals(defOutput) ? " [Default]" : string.Empty)}");
	}
**Example of setting the default input device to the first item returned from enumeration:**

	var firstDevice = 
	    CoreAudio.EnumerateAudioDevices(AudioDeviceType.Input).First();
	CoreAudio.SetDefaultAudioDevice(firstDevice);