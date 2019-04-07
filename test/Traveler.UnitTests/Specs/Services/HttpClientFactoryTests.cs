using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Traveler.Services;
using Traveler.UnitTests.Support;

namespace Traveler.UnitTests.Specs.Services
{
    public class HttpClientFactoryTests : TestBase
    {
        private HttpClientFactory _httpClientFactory;

        [SetUp]
        public void SetUp()
        {
            _httpClientFactory = _autoFake.Resolve<HttpClientFactory>();
        }

        [Test]
        public void GetClientShouldReturnNewHttpClientWithBaseAddressFromLocalhostAddressLocator()
        {
            var localhostAddress = "http://localhost:3000";

            A.CallTo(() => _autoFake.Resolve<ILocalhostAddressLocator>().BaseAddress)
                .Returns(localhostAddress);

            var httpClient = _httpClientFactory.GetClient();

            httpClient.BaseAddress.Should().Be(localhostAddress);
        }
    }
}
