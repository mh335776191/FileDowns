using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlFileDown.Tool
{
    public static class CommonSettings
    {
        public static string SaveOptionPath
        {
            get { return System.Configuration.ConfigurationSettings.AppSettings["SaveOptionPath"]; }
        }
        public static string SaveFilePath
        {
            get { return System.Configuration.ConfigurationSettings.AppSettings["SaveFilePath"]; }
        }
    }
}
