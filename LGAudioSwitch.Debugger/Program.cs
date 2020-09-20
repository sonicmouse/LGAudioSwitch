using LGAudioSwitch.Models;
using System;
using System.Linq;

namespace LGAudioSwitch.Debugger
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("What would you like to do?");
				Console.WriteLine("\t1) List devices");
				Console.WriteLine("\t2) Change default output device");
				Console.WriteLine("\t3) Change default input device");
				Console.WriteLine("\t4) Quit");
				if(int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out var choice))
				{
					AudioDevice[] devices;
					if(choice == 1)
					{
						var defInput = CoreAudio.GetDefaultInputAudioDevice();
						var defOutput = CoreAudio.GetDefaultOutputAudioDevice();

						Console.WriteLine();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("Input devices:");
						foreach (var dev in CoreAudio.EnumerateAudioDevices(AudioDeviceType.Input))
						{
							Console.WriteLine($"\t{dev}{(dev.Equals(defInput) ? " [Default]" : string.Empty)}");
						}

						Console.WriteLine("Output devices:");
						foreach (var dev in CoreAudio.EnumerateAudioDevices(AudioDeviceType.Output))
						{
							Console.WriteLine($"\t{dev}{(dev.Equals(defOutput) ? " [Default]" : string.Empty)}");
						}
						Console.ResetColor();
						Console.WriteLine();
						continue;
					}
					else if(choice == 2)
					{
						devices = CoreAudio.EnumerateAudioDevices(AudioDeviceType.Output).ToArray();
					}
					else if(choice == 3)
					{
						devices = CoreAudio.EnumerateAudioDevices(AudioDeviceType.Input).ToArray();
					}
					else if(choice == 4)
					{
						break;
					}
					else
					{
						continue;
					}

					Console.WriteLine();
					Console.WriteLine("Select device:");
					for(var i = 0; i < devices.Length; ++i)
					{
						Console.WriteLine($"\t{i + 1}) {devices[i]}");
					}
					if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out var devInd))
					{
						devInd -= 1;
						if(devInd >= 0 && (devInd < devices.Length))
						{
							CoreAudio.SetDefaultAudioDevice(devices[devInd]);
							Console.WriteLine("Success");
						}
					}
					Console.WriteLine();
				}
			}
		}
	}
}
