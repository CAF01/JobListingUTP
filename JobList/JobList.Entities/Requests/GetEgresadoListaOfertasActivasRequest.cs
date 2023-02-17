namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoListaOfertasActivasRequest : Pagination, IRequest<PaginationListResponse<GetEgresadoListaOfertasActivasResponse>>
    {
        public int idUsuario { get; set; }
    }
}
