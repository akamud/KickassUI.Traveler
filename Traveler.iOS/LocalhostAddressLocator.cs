using System;
using Traveler.Services;

namespace Traveler.iOS
{
    public class LocalhostAddressLocator : ILocalhostAddressLocator
    {
        public string BaseAddress => "http://localhost:3000";
    }
}
