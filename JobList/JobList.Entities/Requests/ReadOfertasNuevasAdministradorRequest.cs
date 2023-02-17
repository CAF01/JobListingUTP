namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using MediatR;
    public class ReadOfertasNuevasAdministradorRequest : Pagination, IRequest<List<ReadOfertasNuevasAdministradorResponse>>
    {
    }
}
