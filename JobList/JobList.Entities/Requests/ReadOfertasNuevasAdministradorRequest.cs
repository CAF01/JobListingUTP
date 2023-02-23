namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class ReadOfertasNuevasAdministradorRequest : Pagination, IRequest<PaginationListResponse<ReadOfertasNuevasAdministradorResponse>>
    {
    }
}
