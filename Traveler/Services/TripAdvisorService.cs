﻿using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Traveler.Models;

namespace Traveler.Services
{
    public class TripAdvisorService : ITripAdvisorService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public TripAdvisorService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClientFactory.GetClient();
        }

        public async Task<TripAdvisorResponse> GetDestinations()
        {
            var destinationsJson = await _httpClient.GetStringAsync("places");

            return JsonConvert.DeserializeObject<TripAdvisorResponse>(destinationsJson);
        }
    }
}
