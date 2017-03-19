using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BankApi.Library.MessageHandlers
{
    public class ReceiverCryptographyMessageHandler : CryptographyMessageHandlerBase
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestContent = request.Content.ReadAsStringAsync().Result;

            log.Info("Request Bank.WebApi Encrypted Content: " + requestContent);
            request.Content = DecryptContent(requestContent);
            log.Info("Request Bank.WebApi Decrypted Content: " + request.Content.ReadAsStringAsync().Result);

            log.Info("=====================================");

            var response = await base.SendAsync(request, cancellationToken);

            var responseContent = response.Content.ReadAsStringAsync().Result;

            log.Info("Response Bank.WebApi Normal Content: " + responseContent);
            response.Content = EncryptContent(responseContent);
            log.Info("Response Bank.WebApi Encrypted Content: " + response.Content.ReadAsStringAsync().Result);
            return response;
        }
    }
}