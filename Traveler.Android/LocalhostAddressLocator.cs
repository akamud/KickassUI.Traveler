using Traveler.Services;

namespace Traveler.Droid
{
    public class LocalhostAddressLocator : ILocalhostAddressLocator
    {
        public string BaseAddress => "http://10.0.2.2:3000";
    }
}
