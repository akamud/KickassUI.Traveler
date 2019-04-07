using System;
using Prism.Mvvm;
using Prism.Navigation;
using Traveler.Models;

namespace Traveler
{
    public class PlacePageViewModel : BindableBase, INavigatingAware
    {
        public Destination Destination { get; set; }

        public PlacePageViewModel()
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Destination = parameters.GetValue<Destination>("Destination");
        }
    }
}
