using System;
using System.Net.Http;
using Traveler.Services;

namespace Traveler.UnitTests.Fakes
{
    public class FakeHttpClientFactory : IHttpClientFactory
    {
        private readonly ILocalhostAddressLocator _localhostAddressLocator;

        public FakeHttpClientFactory(ILocalhostAddressLocator localhostAddressLocator)
        {
            _localhostAddressLocator = localhostAddressLocator;
        }

        public HttpClient GetClient() => new HttpClient(new FakeHttpClientMessageHandler())
        {
            BaseAddress = new Uri(_localhostAddressLocator.BaseAddress)
        };
    }
}
