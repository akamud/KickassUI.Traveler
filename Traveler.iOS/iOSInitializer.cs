using Prism;
using Prism.Ioc;
using Traveler.Services;

namespace Traveler.iOS
{
    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILocalhostAddressLocator, LocalhostAddressLocator>();
        }
    }
}
