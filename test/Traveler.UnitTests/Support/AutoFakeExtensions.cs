using System;
using Autofac.Extras.FakeItEasy;
using FakeItEasy;
using Traveler.Services;
using Traveler.UnitTests.Fakes;

namespace Traveler.UnitTests.Support
{
    public static class AutoFakeExtensions
    {
        public static AutoFake WithFakeHttpClient(this AutoFake autoFake, string baseAddress)
        {
            A.CallTo(() => autoFake.Resolve<ILocalhostAddressLocator>().BaseAddress)
                .Returns(baseAddress);

            autoFake.Provide<IHttpClientFactory>(new FakeHttpClientFactory(autoFake.Resolve<ILocalhostAddressLocator>()));

            return autoFake;
        }
    }
}
