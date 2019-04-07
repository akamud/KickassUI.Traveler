using Xamarin.UITest;
using Xamarin.UITest.Configuration;

namespace Traveler.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("io.thewissen.Traveler")
                    .StartApp(AppDataMode.Clear);
            }

            return ConfigureApp
                .iOS
                .DeviceIdentifier("FB26DC00-B409-45A9-A422-8115EBDCD3A8")
                .InstalledApp("io.thewissen.Traveler")
                .StartApp(AppDataMode.Clear);
        }
    }
}
