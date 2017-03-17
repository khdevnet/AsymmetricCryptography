using log4net;
using System.Net.Http;
using System.Text;

namespace BankApi.Library.MessageHandlers
{
    public abstract class CryptographyMessageHandlerBase : DelegatingHandler
    {
        protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly AsymmetricСryptographer asymmetricСryptographer;

        public CryptographyMessageHandlerBase()
        {
            asymmetricСryptographer = new AsymmetricСryptographer();
        }

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