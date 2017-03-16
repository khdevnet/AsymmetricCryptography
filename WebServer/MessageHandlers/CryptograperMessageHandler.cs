using Common;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer.MessageHandlers
{
    public class СryptographerMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Process request");
            var decryptedContent = new AsymmetricСryptographer().Decrypt(request.Content.ReadAsStringAsync().Result);
            request.Content = new StringContent(decryptedContent, Encoding.UTF8, "application/json");
            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);
            Debug.WriteLine("Process response");
            return response;
        }
    }
}