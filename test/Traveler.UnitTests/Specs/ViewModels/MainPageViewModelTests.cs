using System;
using AutoBogus;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Prism.Navigation;
using Traveler.Models;
using Traveler.Services;
using Traveler.UnitTests.Support;

namespace Traveler.UnitTests.Specs.ViewModels
{
    public class MainPageViewModelTests : TestBase
    {
        private MainPageViewModel _mainPageViewModel;
        private AutoFaker<Destination> _destinationBuilder;

        [SetUp]
        public void SetUp()
        {
            _mainPageViewModel = _autoFake.Resolve<MainPageViewModel>();
            _destinationBuilder = new AutoFaker<Destination>();
        }

        [Test]
        public void ShowDestinationCommandShouldNavigateToPlacePage()
        {
            _mainPageViewModel.ShowDestinationCommand.Execute(_destinationBuilder.Generate());

            A.CallTo(() => _autoFake.Resolve<INavigationService>().NavigateAsync(nameof(PlacePage), A<NavigationParameters>._))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void ShowDestinationCommandShouldPassSelectedDestinationParameter()
        {
            var selectedDestination = _destinationBuilder.Generate();
            _mainPageViewModel.ShowDestinationCommand.Execute(selectedDestination);

            A.CallTo(() => _autoFake.Resolve<INavigationService>()
                                    .NavigateAsync(A<string>._, 
                                        A<NavigationParameters>.That.Matches(x => x.GetValue<Destination>("Destination") == selectedDestination )))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void OnNavigatingToShouldFillTripAdvisorResopnseWithResponseFromApi()
        {
            var tripAdvisorResponse = new AutoFaker<TripAdvisorResponse>().Generate();

            A.CallTo(() => _autoFake.Resolve<ITripAdvisorService>().GetDestinations())
                .Returns(tripAdvisorResponse);

            _mainPageViewModel.OnNavigatingTo(new NavigationParameters());

            _mainPageViewModel.TripAdvisorResponse.Should().BeEquivalentTo(tripAdvisorResponse);
        }
    }
}
