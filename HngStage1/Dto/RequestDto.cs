namespace HngStage1.Dto
{
    public class RequestDto
    {
        public string SlackName { get; set; }
        public string CurrentDay { get; set; }
        public DateTime UtcTime { get; set; }
        public string Track { get; set; }
        public string GitHubFileUrl { get; set; }
        public string GitHubRepoUrl { get; set; }
        public int StatusCode { get; set; }
    }
}
