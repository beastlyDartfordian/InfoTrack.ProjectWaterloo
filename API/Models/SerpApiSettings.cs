namespace API.Models
{
    public class SerpApiSettings
    {
        public string Engine { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public string Domain { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string Language { get; set; } = String.Empty;
        public string ResultCount { get; set; } = String.Empty;
        public string ApiKey { get; set; } = String.Empty;
    }
}
