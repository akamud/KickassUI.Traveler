using System.Collections.Generic;
using Newtonsoft.Json;

namespace Traveler.Models
{
    public class TripAdvisorResponse
    {
        public List<Destination> Destinations { get; set; } = new List<Destination>();
        public Destination RecommendedDestination { get; set; }
    }
}
