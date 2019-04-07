using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace Traveler.Droid
{
    [Activity(Label = "Traveler", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var xfApplication = new App(new AndroidInitializer());
#if DEBUG
            HotReloader.Current.Start(xfApplication, 4290);
#endif

            LoadApplication(xfApplication);
        }
    }
}