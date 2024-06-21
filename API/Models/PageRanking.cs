namespace API.Models
{    
    public class PageRanking
    {
        public bool Success { get; set; }
        public bool Found { get; set; }
        public string Message { get; set; }
        public string SearchTerm { get; set; }
        public string SearchUrl { get; set; }
        public int? Ranking { get; set; }
    }
}
