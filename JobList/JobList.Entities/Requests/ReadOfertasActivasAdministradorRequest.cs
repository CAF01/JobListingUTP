namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using MediatR;
    public class ReadOfertasActivasAdministradorRequest : Pagination, IRequest<List<ReadOfertasActivasAdministradorResponse>>
    {
    }
}
