using HngStage1.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Collections;

namespace HngStage1.Model
{
    public class HngService : IHngService

    {
        private readonly HngDbContext _dbContext;
        public HngService(HngDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Request> Requests(GetRequest getRequest)
        {
            IQueryable<Request> requests = _dbContext.Requests;
            if (!string.IsNullOrEmpty(getRequest.SlackName))
            {
                requests = requests.Where(x => x.SlackName == getRequest.SlackName);
            }
            if (!string.IsNullOrEmpty(getRequest.Track))
            {
                requests = requests.Where(x => x.Track == getRequest.Track);
            }
            var newRequest = new Request
            {
                SlackName = "Pedro",
                Track = " Backend",
                CurrentDay = DateTime.UtcNow.ToString("dddd"),
                UtcTime = DateTime.UtcNow,
                GitHubFileUrl = "https://github.com/aayangunna/HngService",
                GitHubRepoUrl = "https://github.com/aayangunna/HngService",
                StatusCode = StatusCodes.Status200OK
            };
            var hngRequest = requests.ToList();
            return hngRequest;
            

            //var matchingData = _dbContext.Requests.FirstOrDefault(data =>
            //string.Equals(data.SlackName, getRequest.SlackName, StringComparison.OrdinalIgnoreCase) &&
            //string.Equals(data.Track, getRequest.Track, StringComparison.OrdinalIgnoreCase));
            //if (matchingData == null)
            //{
            //    return null;
            //}

            //return matchingData;
        }


          
        
    }
}
