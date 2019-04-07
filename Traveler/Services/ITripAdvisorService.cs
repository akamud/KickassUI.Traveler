using System.Collections.Generic;
using System.Threading.Tasks;
using Traveler.Models;

namespace Traveler.Services
{
    public interface ITripAdvisorService
    {
        Task<TripAdvisorResponse> GetDestinations();
    }
}