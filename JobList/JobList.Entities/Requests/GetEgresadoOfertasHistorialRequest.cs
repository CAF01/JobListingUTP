namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoOfertasHistorialRequest : Pagination, IRequest<PaginationListResponse<GetEgresadoOfertasHistorialResponse>>
    {
        public int idUsuario { get; set; }
    }
}
