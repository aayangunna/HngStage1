using System.ComponentModel.DataAnnotations;

namespace HngStage1.Model
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public string SlackName { get; set; }
        public string CurrentDay { get; set; }
        public DateTime UtcTime { get; set; }
        public string Track { get; set; }
        public string GitHubFileUrl { get; set; }   
        public string GitHubRepoUrl { get; set; }
        public int StatusCode { get; set; }

        public Request() 
        {
            CurrentDay = DateTime.UtcNow.ToString("dddd");
            UtcTime = DateTime.UtcNow;
            StatusCode = StatusCodes.Status200OK;
        }

    }
}
