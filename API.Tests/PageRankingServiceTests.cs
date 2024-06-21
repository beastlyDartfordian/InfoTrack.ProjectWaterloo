using System.Text.Json;
using API.Models;
using API.Services;
using Microsoft.Extensions.Logging;
using FakeItEasy;
using SerpApi;

namespace API.Tests.Services
{
    public class PageRankingServiceTests
    {
        private readonly ISerpApiService fakeSerpApiService;
        private readonly IPageRankingService pageRankingService;

        public PageRankingServiceTests()
        {
            this.fakeSerpApiService = A.Fake<ISerpApiService>();

            this.pageRankingService = new PageRankingService(fakeSerpApiService);
        }

        [Fact]
        public void GetResult_Success_PageRankingFound()
        {
            // Arrange
            var searchTerm = "test";
            var searchUrl = "https://example.com";
            var serpApiResult = new SerpApiResult
            {
                SearchMetadata = new SearchMetadata { Status = "Success" },
                OrganicResults = new List<OrganicResult>
                {
                    new OrganicResult { Link = "https://example.com", Position = 1 }
                }
            };

            A.CallTo(() => this.fakeSerpApiService.GetResults(A<string>.Ignored))
                .Returns(serpApiResult);

            // Act
            var result = this.pageRankingService.GetPageRanking(searchTerm, searchUrl);

            // Assert
            Assert.True(result.Success);
            Assert.True(result.Found);
            Assert.Equal(1, result.Ranking);
            Assert.Null(result.Message);
        }

        [Fact]
        public void GetResult_Success_PageRankingNotFound()
        {
            // Arrange
            var searchTerm = "test";
            var searchUrl = "https://nonexistent.com";
            var serpApiResult = new SerpApiResult
            {
                SearchMetadata = new SearchMetadata { Status = "Success" },
                OrganicResults = new List<OrganicResult>
                {
                    new OrganicResult { Link = "https://example.com", Position = 1 }
                }
            };
            
            A.CallTo(() => this.fakeSerpApiService.GetResults(A<string>.Ignored))
                .Returns(serpApiResult);

            // Act
            var result = this.pageRankingService.GetPageRanking(searchTerm, searchUrl);

            // Assert
            Assert.True(result.Success);
            Assert.False(result.Found);
            Assert.Equal("Url not found within search results", result.Message);
        }

        [Fact]
        public void GetResult_Fail_ReturnsErrorMessage()
        {
            // Arrange
            var searchTerm = "test";
            var searchUrl = "https://example.com";
            var serpApiResult = new SerpApiResult
            {
                SearchMetadata = new SearchMetadata { Status = "Error", ErrorMessage = "API Error" }
            };

            A.CallTo(() => this.fakeSerpApiService.GetResults(A<string>.Ignored))
                .Returns(serpApiResult);

            // Act
            var result = this.pageRankingService.GetPageRanking(searchTerm, searchUrl);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("API Error", result.Message);
        }
    }
}