using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BankApi.Library.MessageHandlers
{
    public class ReceiverCryptographyMessageHandler : CryptographyMessageHandlerBase
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string requestContent = request.Content.ReadAsStringAsync().Result;

            Log.Info("Request Bank.WebApi Encrypted Content: " + requestContent);
            request.Content = DecryptContent(requestContent);
            Log.Info("Request Bank.WebApi Decrypted Content: " + request.Content.ReadAsStringAsync().Result);
            Log.Info("=====================================");

            return await base.SendAsync(request, cancellationToken);
        }
    }
}