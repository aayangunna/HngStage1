using HngStage1.Dto;
using HngStage1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HngStage1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HngController : ControllerBase
    {
        private readonly IHngService _service;
        public HngController(IHngService hngService)
        {
            _service = hngService;
        }
        [HttpGet("GetDb")]
        public IActionResult GetDetails([FromQuery] GetRequest getRequest)
        {
            var result = _service.Requests(getRequest);
            {
                return Ok(result);
            }

        }



        private static List<RequestDto> requestDataList = new List<RequestDto>
        {
            new RequestDto
            {
                SlackName = "Pedro",
                CurrentDay = DateTime.UtcNow.ToString("dddd"),
                UtcTime = DateTime.UtcNow,
                Track = "backend",
                GitHubFileUrl = "https://github.com/aayangunna/repo/blob/main/file_name.ext",
                GitHubRepoUrl = "https://github.com/aayangunna/repo",
                StatusCode = 200
            }
        };

        [HttpGet("Get")]
        public IActionResult Get([FromQuery] string slack_name, [FromQuery] string track)
        {
            // Find the matching data based on query parameters
            var matchingData = requestDataList.FirstOrDefault(data =>
                string.Equals(data.SlackName, slack_name, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(data.Track, track, StringComparison.OrdinalIgnoreCase));

            if (matchingData == null)
            {
                return NotFound();
            }

            return Ok(matchingData);
        }
    }
}
