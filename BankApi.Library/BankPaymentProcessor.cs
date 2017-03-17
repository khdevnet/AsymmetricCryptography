using BankApi.Library.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankApi.Library
{
    public class BankPaymentProcessor
    {
        public async Task<HttpResponseMessage> PayNowAsync(CreditCard creditCard)
        {
            HttpClient client = BankHttpClient.Create();
            var content = new StringContent(JsonConvert.SerializeObject(creditCard), Encoding.UTF8, "application/json");
            return await client.PostAsync("api/processor", content);
        }
    }
}