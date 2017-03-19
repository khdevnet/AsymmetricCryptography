using BankApi.Library.Readers;

namespace BankApi.Library
{
    public class Configuration
    {
        private readonly string encryptionKeysPath;
        private readonly string decryptionKeysPath;
        private string bankApiUrl;

        public Configuration()
        {
            encryptionKeysPath = AppSettingReader.GetSetting("EncryptionKeysPath");
            decryptionKeysPath = AppSettingReader.GetSetting("DecryptionKeysPath");
            bankApiUrl = AppSettingReader.GetSetting("bankApiUrl");
        }

        public string EncryptionKeysPath => encryptionKeysPath;

        public string DecryptionKeysPath => decryptionKeysPath;

        public string BankApiUrl => bankApiUrl;
    }
}