using FluentAssertions;
using NUnit.Framework;
using Traveler.UITests.Pages;
using Traveler.UITests.Support;
using Xamarin.UITest;

namespace Traveler.UITests.Specs
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class MainPageTests : TestSetup<MainPage>
    {
        public MainPageTests(Platform platform) : base(platform) { }

        [Test]
        public void RecommendedDestinationIsShown()
        {
            Page.WaitForLoad();

            Page.RecommendedDestinationTitle.Should().Be("Seattle, USA");
            Page.RecommendedDestinationRating.Should().Be("4.3  (3478 votes)");
        }

        [Test]
        public void HotPlacesAreShown()
        {
            Page.WaitForLoad();

            Page.FirstHotPlaceTitle.Should().Be("Ulun Danu Beratan Temple");
        }

        [Test]
        public void ClickingHotPlaceNavigatesToDetails()
        {
            Page.SelectHotPlace("Ulun Danu Beratan Temple");

            var placePage = new PlacePage(App);
            placePage.WaitForLoad();
        }
    }
}
