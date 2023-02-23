namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class ReadOfertasActivasFiltroEgresadoRequest : Pagination,IRequest<PaginationListResponse<ReadOfertasActivasFiltroEgresadoResponse>>
    {
        public int idUsuarioEgresado { get; set; }
    }
}
