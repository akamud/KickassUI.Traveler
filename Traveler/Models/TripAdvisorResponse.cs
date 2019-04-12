using System.Collections.Generic;
using Newtonsoft.Json;

namespace Traveler.Models
{
    public class TripAdvisorResponse
    {
        [JsonProperty("hot_places")]
        public List<Destination> Destinations { get; set; } = new List<Destination>();
        [JsonProperty("recommended")]
        public Destination RecommendedDestination { get; set; }
    }
}
