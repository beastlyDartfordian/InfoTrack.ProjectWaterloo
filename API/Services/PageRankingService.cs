using API.Models;

namespace API.Services
{
    public class PageRankingService : IPageRankingService
    {
        private ISerpApiService serpApiSservice;

        public PageRankingService(ISerpApiService serpApiSservice)
        {
            this.serpApiSservice = serpApiSservice;
        }

        public PageRanking GetPageRanking(string searchTerm, string searchUrl)
        {
            var rankingResult = new PageRanking
            {
                SearchTerm = searchTerm,
                SearchUrl = searchUrl
            };

            var results = this.serpApiSservice.GetResults(searchTerm);

            if (!results.SearchMetadata.Success)
            {
                rankingResult.Message = results.SearchMetadata.ErrorMessage;

                return rankingResult;
            }

            rankingResult.Success = true;

            if (!searchUrl.StartsWith("https://"))
            {
                searchUrl = $"https://{searchUrl}";
            }

            var matchedResult = results.OrganicResults.SingleOrDefault(or => or.Link.StartsWith(searchUrl), null);

            if (matchedResult is null)
            {
                rankingResult.Message = "Url not found within search results";

                return rankingResult;
            }

            rankingResult.Found = true;
            rankingResult.Ranking = matchedResult.Position;

            return rankingResult;
        }
    }
}
