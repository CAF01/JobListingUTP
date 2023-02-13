using JobList.Entities.Responses;
using MediatR;

namespace JobList.Entities.Requests
{
    public class ReadOfertasRevisionDocenteRequest : IRequest<List<ReadOfertasRevisionDocenteResponse>>
    {
        public int idUsuarioDocente { get; set; }
    }
}
