using JobList.Entities.Responses;
using MediatR;


namespace JobList.Entities.Requests
{
    public class ReadAreasDivisionRequest : IRequest<IEnumerable<ReadAreasDivisionResponse>>
    {
        public int idDivision { get; set; }
    }
}
