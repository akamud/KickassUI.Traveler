using Autofac.Extras.FakeItEasy;
using Flurl.Http.Testing;
using NUnit.Framework;

namespace Traveler.UnitTests.Support
{
    public abstract class TestBase
    {
        protected AutoFake _autoFake;
        protected HttpTest _httpTest;

        [SetUp]
        public void SetUpBase()
        {
            _autoFake = new AutoFake();
            _httpTest = new HttpTest();
        }

        [TearDown]
        public void TearDownBase()
        {
            _autoFake.Dispose();
            _httpTest.Dispose();
        }
    }
}
