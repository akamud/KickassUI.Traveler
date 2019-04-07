using Prism;
using Prism.Ioc;
using Traveler.Services;

namespace Traveler.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILocalhostAddressLocator, LocalhostAddressLocator>();
        }
    }
}
