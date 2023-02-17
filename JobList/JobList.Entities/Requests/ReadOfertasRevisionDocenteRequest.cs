using JobList.Entities.Models;
using JobList.Entities.Responses;
using MediatR;

namespace JobList.Entities.Requests
{
    public class ReadOfertasRevisionDocenteRequest : Pagination, IRequest<PaginationListResponse<ReadOfertasRevisionDocenteResponse>>
    {
        public int idUsuarioDocente { get; set; }
    }
}
