using HngStage1.Dto;

namespace HngStage1.Model
{
    public interface IHngService
    {
        IEnumerable<Request> Requests(GetRequest getRequest);
    }
}
