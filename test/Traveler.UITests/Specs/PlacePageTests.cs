using FluentAssertions;
using NUnit.Framework;
using Traveler.UITests.Pages;
using Traveler.UITests.Support;
using Xamarin.UITest;

namespace Traveler.UITests.Specs
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class PlacePageTests : TestSetup<PlacePage>
    {
        public PlacePageTests(Platform platform) : base(platform) { }

        [SetUp]
        public void SetUp()
        {
            var mainPage = new MainPage(App);

            mainPage.SelectHotPlace("Ulun Danu Beratan Temple");
        }

        [Test]
        public void HotPlaceIsShown()
        {
            Page.WaitForLoad();

            Page.DestinationTitle.Should().Be("Ulun Danu Beratan Temple");
            Page.DestinationRating.Should().Be("4.4  (3829 votes)");
            Page.DestinationDescription.Should().StartWith("Lorem Ipsum");
        }
    }
}
