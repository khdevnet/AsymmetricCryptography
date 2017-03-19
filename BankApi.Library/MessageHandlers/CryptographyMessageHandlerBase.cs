using System.Net.Http;
using System.Text;
using BankApi.Library.Common.Logging;

namespace BankApi.Library.MessageHandlers
{
    public abstract class CryptographyMessageHandlerBase : DelegatingHandler
    {
        private readonly AsymmetricСryptographer asymmetricСryptographer = new AsymmetricСryptographer();
        protected Logger log { get; } = new Logger();

        protected StringContent EncryptContent(string content)
        {
            var encryptedContent = asymmetricСryptographer.Encrypt(content);
            return CreateJsonStringContent(encryptedContent);
        }

        protected StringContent DecryptContent(string content)
        {
            var decryptedContent = asymmetricСryptographer.Decrypt(content);
            return CreateJsonStringContent(decryptedContent);
        }

        private static StringContent CreateJsonStringContent(string encryptedContent)
        {
            return new StringContent(encryptedContent, Encoding.UTF8, "application/json");
        }
    }
}