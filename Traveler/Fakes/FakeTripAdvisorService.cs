using System.Threading.Tasks;
using Newtonsoft.Json;
using Traveler.Models;
using Traveler.Services;

namespace Traveler.Fakes
{
    public class FakeTripAdvisorService : ITripAdvisorService
    {
        private string validJson = @"{""recommended_destination"": {
            ""title"": ""Seattle, USA"",
            ""image_url"": ""seattle.jpg"",
            ""rating"": ""4.3"",
            ""votes"": ""3478""
        },
        ""destinations"": [
            {
                ""title"": ""Ulun Danu Beratan Temple"",
                ""image_url"": ""bali.jpg"",
                ""rating"": ""4.4"",
                ""votes"": ""3829""
            },
            {
                ""title"": ""Isola d'Elba"",
                ""image_url"": ""elba.jpg"",
                ""rating"": ""4.9"",
                ""votes"": ""9783""
            }
        ]}";

        public Task<TripAdvisorResponse> GetDestinations()
        {
            return Task.FromResult(JsonConvert.DeserializeObject<TripAdvisorResponse>(validJson));
        }
    }
}
