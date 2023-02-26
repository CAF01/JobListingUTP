namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class ReadConocimientosRequest : IRequest<IEnumerable<ReadConocimientosResponse>>
    {
    }
}
