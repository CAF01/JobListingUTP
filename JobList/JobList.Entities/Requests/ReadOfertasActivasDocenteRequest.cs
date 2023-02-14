using JobList.Entities.Responses;
using MediatR;

namespace JobList.Entities.Requests
{
    public class ReadOfertasActivasDocenteRequest : IRequest<IEnumerable<ReadOfertasActivasDocenteResponse>>
    {
        public int idUsuarioDocente { get; set; }
    }
}
