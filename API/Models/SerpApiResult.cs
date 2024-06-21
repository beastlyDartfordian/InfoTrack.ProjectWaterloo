using Microsoft.AspNetCore.Http.HttpResults;
using System.Globalization;
using System.Text.Json;

namespace API.Models
{
    public class SerpApiResult
    {
        public SearchMetadata SearchMetadata { get; set; }
        public SearchInformation SearchInformation { get; set; }
        public List<OrganicResult> OrganicResults { get; set; }
    }

    public class SearchMetadata
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string JsonEndpoint { get; set; }
        public string CreatedAt { get; set; }
        public string ProcessedAt { get; set; }
        public string GoogleUrl { get; set; }
        public string RawHtmlFile { get; set; }
        public decimal TotalTimeTaken { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success => Status.ToLower() == "success";
        public DateTime CreatedAtDateTime => DateTime.ParseExact(CreatedAt, dateFormat, CultureInfo.InvariantCulture);
        public DateTime ProcessedAtDateTime => DateTime.ParseExact(ProcessedAt, dateFormat, CultureInfo.InvariantCulture);
        private readonly string dateFormat = "yyyy-MM-dd HH:mm:ss 'UTC'";
    }

    public class SearchInformation
    {
        public string QueryDisplayed { get; set; }
        public int TotalResults { get; set; }
        public decimal TimeTakenDisplayed { get; set; }
        public string OrganicResultsState { get; set; }
    }

    public class OrganicResult
    {
        public int Position { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string RedirectLink { get; set; }
        public string DisplayedLink { get; set; }
        public string Favicon { get; set; }
        public string Snippet { get; set; }
        public List<string> SnippetHighlightedWords { get; set; }
    }
}
