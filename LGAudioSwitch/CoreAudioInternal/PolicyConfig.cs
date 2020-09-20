using System;
using System.Runtime.InteropServices;

namespace LGAudioSwitch.CoreAudioInternal
{
	internal static class PolicyConfig
	{
		public static void SetDefaultEndpoint(string devId, ERole eRole)
		{
			PolicyConfigClient policyConfig = null;
			try
			{
				policyConfig = new PolicyConfigClient();

				if (policyConfig is IPolicyConfigX policyConfigX)
				{
					Marshal.ThrowExceptionForHR(policyConfigX.SetDefaultEndpoint(devId, eRole));
				}
				else if (policyConfig is IPolicyConfig policyConfig7)
				{
					Marshal.ThrowExceptionForHR(policyConfig7.SetDefaultEndpoint(devId, eRole));
				}
				else if (policyConfig is IPolicyConfigVista policyConfigVista)
				{
					Marshal.ThrowExceptionForHR(policyConfigVista.SetDefaultEndpoint(devId, eRole));
				}
			}
			finally
			{
				if (policyConfig != null && Marshal.IsComObject(policyConfig))
					Marshal.FinalReleaseComObject(policyConfig);

				GC.Collect();
			}
		}

		[ComImport, Guid("870AF99C-171D-4F9E-AF0D-E63DF40C2BC9")]
		private class PolicyConfigClient
		{
		}
	}
}