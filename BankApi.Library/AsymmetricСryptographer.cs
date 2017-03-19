using BankApi.Library.Readers;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BankApi.Library
{
    public class AsymmetricСryptographer
    {
        private readonly string encryptionKeysPath;
        private readonly string decryptionKeysPath;

        public AsymmetricСryptographer()
        {
            encryptionKeysPath = AppSettingReader.GetSetting("EncryptionKeysPath");
            decryptionKeysPath = AppSettingReader.GetSetting("DecryptionKeysPath");
        }

        public string Encrypt(string plainText)
        {
            byte[] cipherText = CreateСryptographer(encryptionKeysPath)
                .Encrypt(Encoding.UTF8.GetBytes(plainText), false);
            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string cipherText)
        {
            byte[] original = CreateСryptographer(decryptionKeysPath)
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