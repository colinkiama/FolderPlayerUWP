using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;

namespace FolderPlayerUWP.Helpers
{
    public static class DeviceFamilyHelper
    {
        public static bool checkIfMoblie()
        {
            bool isDeviceMobile = false;

            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {
                isDeviceMobile = true;
            }
            
            return isDeviceMobile;
        }
    }
}
