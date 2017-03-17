using System;
using System.Security.Cryptography;
using System.Text;

namespace BankApi.Library
{
    public class AsymmetricСryptographer
    {
        private readonly string EncryptionKeysPath;
        private readonly string DecryptionKeysPath;

        public AsymmetricСryptographer()
        {
            EncryptionKeysPath = AppSettingReader.GetSetting("EncryptionKeysPath");
            DecryptionKeysPath = AppSettingReader.GetSetting("DecryptionKeysPath");
        }

        public string Encrypt(string plainText)
        {
            byte[] cipherText = CreateСryptographer(EncryptionKeysPath)
                .Encrypt(Encoding.UTF8.GetBytes(plainText), false);
            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string cipherText)
        {
            byte[] original = CreateСryptographer(DecryptionKeysPath)
                .Decrypt(Convert.FromBase64String(cipherText), false);
            return Encoding.UTF8.GetString(original);
        }

        private RSACryptoServiceProvider CreateСryptographer(string keysFile)
        {
            RSACryptoServiceProvider cryptographer = new RSACryptoServiceProvider();
            cryptographer.FromXmlString(new FileReader().Read(keysFile));
            return cryptographer;
        }
    }
}