namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class ReadHistorialOfertasDocenteRequest : Pagination, IRequest<PaginationListResponse<ReadHistorialOfertasDocenteResponse>>
    {
        public int idUsuarioDocente { get; set; }
    }
}
