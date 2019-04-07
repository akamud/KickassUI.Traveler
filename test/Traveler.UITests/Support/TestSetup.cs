using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace Traveler.UITests.Support
{
    public abstract class TestSetup<TPage> : TestSetup
                where TPage : Page
    {
        protected TPage Page;

        protected TestSetup(Platform platform) : base(platform) { }

        [SetUp]
        public new void BeforeEachTest()
            => Page = (TPage)Activator.CreateInstance(typeof(TPage), App);
    }

    public abstract class TestSetup
    {
        protected IApp App;
        protected readonly Platform _platform;

        protected TestSetup(Platform platform)
            => _platform = platform;

        [SetUp]
        public void BeforeEachTest()
            => App = AppInitializer.StartApp(_platform);
    }
}
