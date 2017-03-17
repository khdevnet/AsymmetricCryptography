using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BankApi.Library.MessageHandlers
{
    public class DecryptMessageHandler : CryptographyMessageHandlerBase
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestContent = request.Content.ReadAsStringAsync().Result;
            Log.Info("Request Bank.WebApi Encrypted Content: " + requestContent);
            request.Content = DecryptContent(requestContent);
            Log.Info("Request Bank.WebApi Decrypted Content: " + request.Content.ReadAsStringAsync().Result);
            var response = await base.SendAsync(request, cancellationToken);

            var responseContent = response.Content.ReadAsStringAsync().Result;
            Log.Info("Response Bank.WebApi Normal Content: " + responseContent);
            response.Content = EncryptContent(responseContent);
            Log.Info("Response Bank.WebApi Encrypted Content: " + response.Content.ReadAsStringAsync().Result);
            return response;
        }
    }
}