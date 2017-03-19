using System;
using System.Net.Http;
using System.Net.Http.Headers;
using BankApi.Library.MessageHandlers;
using BankApi.Library.Readers;

namespace BankApi.Library
{
    public static class BankHttpClient
    {
        public static HttpClient Create()
        {
            var client = HttpClientFactory.Create(new WebRequestHandler(), new[] { new SenderCryptographyMessageHandler() });
            client.BaseAddress = new Uri(AppSettingReader.GetSetting("bankApiUrl"));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}