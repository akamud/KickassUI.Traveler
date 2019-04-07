using System.Threading.Tasks;
using NUnit.Framework;
using Traveler.Services;
using Traveler.UnitTests.Support;

namespace Traveler.UnitTests.Specs.Services
{
    public class TripAdvisorServiceTests : TestBase
    {
        private TripAdvisorService _tripAdvisorService;
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
        private string _localhostAddress;

        [SetUp]
        public void SetUp()
        {
            _localhostAddress = "http://localhost:3000";
            _tripAdvisorService = _autoFake.WithFakeHttpClient(_localhostAddress)
                                           .Resolve<TripAdvisorService>();
        }

        [Test]
        public async Task GetDestinationsShouldCallDestinationsApi()
        {
            _httpTest.RespondWith(validJson);

            await _tripAdvisorService.GetDestinations();

            _httpTest.ShouldHaveCalled($"{_localhostAddress}/destinations");
        }
    }
}
