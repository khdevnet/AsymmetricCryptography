using System.Configuration;

namespace BankApi.Library.Common.Readers
{
    public class AppSettingReader
    {
        public string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}