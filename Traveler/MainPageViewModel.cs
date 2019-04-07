using Prism.Commands;
using Prism.Navigation;
using Traveler.Models;
using Traveler.Services;
using Xamarin.Forms;

namespace Traveler
{
    public class MainPageViewModel : BindableObject, INavigatingAware
    {
        private readonly ITripAdvisorService _tripAdvisorService;
        private readonly INavigationService _navigationService;

        public TripAdvisorResponse TripAdvisorResponse { get; set; }
        public DelegateCommand<Destination> ShowDestinationCommand { get; set; }

        public MainPageViewModel(ITripAdvisorService tripAdvisorService,
                                 INavigationService navigationService)
        {
            _tripAdvisorService = tripAdvisorService;
            _navigationService = navigationService;

            ShowDestinationCommand = new DelegateCommand<Destination>((destination) => _navigationService.NavigateAsync(nameof(PlacePage), new NavigationParameters
            {
                {"Destination", destination}
            }));
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            TripAdvisorResponse = await _tripAdvisorService.GetDestinations();
        }
    }
}
