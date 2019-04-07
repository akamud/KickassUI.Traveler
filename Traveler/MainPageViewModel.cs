using Prism.Navigation;
using Traveler.Models;
using Traveler.Services;
using Xamarin.Forms;

namespace Traveler
{
    public class MainPageViewModel : BindableObject, INavigatingAware
    {
        private readonly ITripAdvisorService _tripAdvisorService;

        public TripAdvisorResponse TripAdvisorResponse { get; set; }

        public MainPageViewModel(ITripAdvisorService tripAdvisorService)
        {
            _tripAdvisorService = tripAdvisorService;
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            TripAdvisorResponse = await _tripAdvisorService.GetDestinations();
        }
    }
}
