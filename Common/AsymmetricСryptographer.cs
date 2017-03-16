using System;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class AsymmetricСryptographer
    {
        public string Encrypt(string plainText)
        {
            byte[] cipherText = CreateСryptographer("EncryptionKeys.xml")
                .Encrypt(Encoding.UTF8.GetBytes(plainText), false);
            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string cipherText)
        {
            byte[] original = CreateСryptographer("DecryptionKeys.xml")
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