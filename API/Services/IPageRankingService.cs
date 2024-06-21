using API.Models;

namespace API.Services
{
    public interface IPageRankingService
    {
        PageRanking GetPageRanking(string searchTerm, string searchUrl);
    }
}
