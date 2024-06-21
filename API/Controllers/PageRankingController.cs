using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PageRankingController : ControllerBase
    {

        private readonly ILogger<PageRankingController> logger;
        private readonly IPageRankingService pageRankingService;

        public PageRankingController(ILogger<PageRankingController> logger, IPageRankingService pageRankingService)
        {
            this.logger = logger;
            this.pageRankingService = pageRankingService;
        }

        // Get api/pageranking/land+registry+search/www.infotrack.co.uk
        [HttpGet("{searchTerm}/{searchUrl}")]
        public PageRanking GetPageRanking(string searchTerm, string searchUrl)
        {
            var result = this.pageRankingService.GetPageRanking(searchTerm, searchUrl);

            return result;
        }

        // Get api/pageranking/land+registry+search/www.infotrack.co.uk/history
        [HttpGet("{searchQuery}/{url}/history")]
        public int? GetPageRankingHistory(string searchQuery)
        {
            return null;
        }
    }
}
