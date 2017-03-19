using System.Configuration;

namespace BankApi.Library.Readers
{
    public static class AppSettingReader
    {
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}