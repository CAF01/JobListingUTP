namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoPostulacionesRequest : Pagination, IRequest<PaginationListResponse<GetEgresadoPostulacionesResponse>>
    {
        public int idUsuario { get; set; }
    }
}
