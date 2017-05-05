using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BankApi.Library.MessageHandlers
{
    public class SenderCryptographyMessageHandler : CryptographyMessageHandlerBase
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string requestContent = request.Content.ReadAsStringAsync().Result;

            Log.Info("Request News Subscribe Web NormalContent: " + requestContent);
            request.Content = EncryptContent(requestContent);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}