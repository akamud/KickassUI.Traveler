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
                .DeviceIdentifier("96EF74AB-F08E-4353-81B6-708249C6CF7C")
                .InstalledApp("io.thewissen.Traveler")
                .StartApp(AppDataMode.Clear);
        }
    }
}
