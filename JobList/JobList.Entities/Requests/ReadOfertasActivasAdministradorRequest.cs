namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class ReadOfertasActivasAdministradorRequest : Pagination, IRequest<PaginationListResponse<ReadOfertasActivasAdministradorResponse>>
    {
    }
}
