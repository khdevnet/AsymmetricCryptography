using BankApi.Library.Common.Readers;

namespace BankApi.Library
{
    public class Configuration
    {
        public Configuration()
        {
            var settingsReader = new AppSettingReader();
            EncryptionKeysPath = settingsReader.GetSetting("EncryptionKeysPath");
            DecryptionKeysPath = settingsReader.GetSetting("DecryptionKeysPath");
            BankApiUrl = settingsReader.GetSetting("bankApiUrl");
        }

        public string EncryptionKeysPath { get; }

        public string DecryptionKeysPath { get; }

        public string BankApiUrl { get; }
    }
}