using System.Linq;
using Traveler.UITests.Support;
using Xamarin.UITest;

namespace Traveler.UITests.Pages
{
    public class PlacePage : Page
    {
        public PlacePage(IApp app) : base(app) { }

        public void WaitForLoad()
        {
            App.WaitForElement(e => e.Marked("Destination Title"));
        }

        public string DestinationTitle => App.WaitForElement(e => e.Marked("Destination Title")).FirstOrDefault().Text;
        public string DestinationRating => App.WaitForElement(e => e.Marked("Destination Rating")).FirstOrDefault().Text;
        public string DestinationDescription => App.WaitForElement(e => e.Marked("Destination Description")).FirstOrDefault().Text;
    }
}
