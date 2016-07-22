using System.Configuration;
using System.Reflection;
using WebApi.Common;

namespace WebApi.Configuration
{
    public class Config : IConfig
    {
        public Config()
        {
            Environment = ConfigurationManager.AppSettings[Constants.Environment];
            Version = GetAssemblyVersion();
        }
        public string Environment { get; }
        public string Version { get; }
        private static string GetAssemblyVersion()
        {            
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            return string.Format("{0}.{1}.{2} (build {3})", version.Major, version.Minor, 
                version.Build, version.Revision);
        }
    }
}