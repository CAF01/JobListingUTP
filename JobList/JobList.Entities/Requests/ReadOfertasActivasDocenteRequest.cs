namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class ReadOfertasActivasDocenteRequest : Pagination, IRequest<PaginationListResponse<ReadOfertasActivasDocenteResponse>>
    {
        public int idUsuarioDocente { get; set; }
    }
}
