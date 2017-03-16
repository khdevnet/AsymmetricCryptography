using Common;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.MessageHandler
{
    public class СryptographerMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestContent = request.Content.ReadAsStringAsync().Result;
            var cryptographer = new AsymmetricСryptographer();
            var encryptedContent = cryptographer.Encrypt(requestContent);
            request.Content = new StringContent(encryptedContent, Encoding.UTF8, "application/json");
            Debug.WriteLine("Process request");
            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);
            Debug.WriteLine("Process response");
            return response;
        }
    }
}