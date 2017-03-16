using Client.MessageHandler;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Client
{
    public static class ShopHttpClient
    {
        private const string ShopUrl = "http://localhost:53978/";

        public static HttpClient Create()
        {
            var client = HttpClientFactory.Create(new СryptographerMessageHandler());//
            client.BaseAddress = new Uri(ShopUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}