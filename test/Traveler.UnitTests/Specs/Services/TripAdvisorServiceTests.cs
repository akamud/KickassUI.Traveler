using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Traveler.Models;
using Traveler.Services;
using Traveler.UnitTests.Support;

#pragma warning disable CS1701, CS1702 // Assuming assembly reference matches identity
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

        [Test]
        public async Task GetDestinationsShouldReturnTripAdvisorResponseCorrectly()
        {
            _httpTest.RespondWith(validJson);

            var destinations = await _tripAdvisorService.GetDestinations();

            destinations.Should().BeEquivalentTo(new TripAdvisorResponse
            {
                RecommendedDestination = new Destination
                {
                    ImageUrl = "seattle.jpg",
                    Rating = 4.3f,
                    Votes = 3478,
                    Title = "Seattle, USA"
                },
                Destinations  = new List<Destination>
                {
                    new Destination
                    {
                        Title = "Ulun Danu Beratan Temple",
                        ImageUrl ="bali.jpg",
                        Rating = 4.4f,
                        Votes = 3829
                    },
                    new Destination
                    {
                        Title = "Isola d'Elba",
                        ImageUrl ="elba.jpg",
                        Rating = 4.9f,
                        Votes = 9783
                    }
                }
            });
        }
    }
}
#pragma warning restore CS1701,CS1702 // Assuming assembly reference matches identity
