using System;
using System.Net.Http;
using System.Net.Http.Headers;
using BankApi.Library.MessageHandlers;

namespace BankApi.Library
{
    public static class BankHttpClient
    {
        private static readonly Configuration configuration = new Configuration();

        public static HttpClient Create()
        {
            var client = HttpClientFactory.Create(new WebRequestHandler(), new[] { new SenderCryptographyMessageHandler() });
            client.BaseAddress = new Uri(configuration.BankApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}