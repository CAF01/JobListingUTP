namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using MediatR;
    public class ReadGenerosRequest : IRequest<List<ReadGenerosResponse>>
    {
    }
}
