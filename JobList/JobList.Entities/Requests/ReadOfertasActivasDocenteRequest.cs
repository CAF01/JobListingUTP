using JobList.Entities.Responses;
using MediatR;

namespace JobList.Entities.Requests
{
    public class ReadOfertasActivasDocenteRequest : IRequest<List<ReadOfertasActivasDocenteResponse>>
    {
        public int idUsuarioDocente { get; set; }
    }
}
