using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSLive247.Utilities
{
    public static class ExtensionUtility
    {
        public static string GetAppSetting(string key)
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static int GetIntAppSetting(string key)
        {
            try
            {
                return int.Parse(System.Configuration.ConfigurationManager.AppSettings[key].ToString());
            }
            catch (Exception ex)
            {
                return 2;
            }
        }

    }
}
