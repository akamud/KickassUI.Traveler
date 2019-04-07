using System.Net.Http;

namespace Traveler.Services
{
    public interface IHttpClientFactory
    {
        HttpClient GetClient();
    }
}