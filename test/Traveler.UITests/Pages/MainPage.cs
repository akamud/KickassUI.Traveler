using System;
using System.Linq;
using Traveler.UITests.Support;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Traveler.UITests.Pages
{
    public class MainPage : Page
    {
        Func<AppQuery, AppQuery> firstHotPlaceQuery = e => e.Marked("Hot Place Title").Index(0);

        public MainPage(IApp app) : base(app) { }

        public void WaitForLoad()
        {
            App.WaitForElement(e => e.Marked("Recommended Destination Title"));
        }

        public string RecommendedDestinationTitle => App.WaitForElement(e => e.Marked("Recommended Destination Title")).FirstOrDefault().Text;
        public string RecommendedDestinationRating => App.WaitForElement(e => e.Marked("Recommended Destination Rating")).FirstOrDefault().Text;

        public string FirstHotPlaceTitle => App.WaitForElement(firstHotPlaceQuery).FirstOrDefault().Text;

        public void SelectHotPlace(string destinationTitle)
        {
            App.Tap(firstHotPlaceQuery);
        }
    }
}
