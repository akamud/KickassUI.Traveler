using AutoBogus;
using FluentAssertions;
using NUnit.Framework;
using Prism.Navigation;
using Traveler.Models;
using Traveler.UnitTests.Support;

namespace Traveler.UnitTests.Specs.ViewModels
{
    public class PlacePageViewModelTests : TestBase
    {
        [Test]
        public void OnNavigatingToShouldFillDestinationWithParameterPassed()
        {
            var destination = new AutoFaker<Destination>().Generate();
            var placePageViewModel = _autoFake.Resolve<PlacePageViewModel>();

            placePageViewModel.OnNavigatingTo(new NavigationParameters
            {
                {"Destination", destination}
            });

            placePageViewModel.Destination.Should().BeEquivalentTo(destination);
        }
    }
}
