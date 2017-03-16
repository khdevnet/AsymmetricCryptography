using Common;
using Common.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main()
        {
            var response = CheckoutAsync(new CreditCard { Value = "Hello" });
            Console.WriteLine(response.Result);

            Console.ReadLine();
        }

        static async Task<CreditCard> CheckoutAsync(CreditCard product)
        {
            HttpClient client = ShopHttpClient.Create();
            HttpResponseMessage response = await client.PostAsJsonAsync("api/checkout", product);
            response.EnsureSuccessStatusCode();

            // Return the URI of the created resource.
            return await response.Content.ReadAsAsync<CreditCard>();
        }
    }
}