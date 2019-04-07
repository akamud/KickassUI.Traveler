using System;
using System.Net.Http;

namespace Traveler.Services
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly ILocalhostAddressLocator localhostAddressLocator;

        public HttpClientFactory(ILocalhostAddressLocator localhostAddressLocator)
        {
            this.localhostAddressLocator = localhostAddressLocator;
        }

        public HttpClient GetClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri(localhostAddressLocator.BaseAddress)
            };
        }
    }
}