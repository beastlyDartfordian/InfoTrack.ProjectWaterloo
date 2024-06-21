using API.Models;

namespace API.Services
{
    public interface ISerpApiService
    {
        SerpApiResult GetResults(string searchTerm, SerpApiSettings? settings = null);
    }
}
