using JobList.Entities.Responses;
using MediatR;

namespace JobList.Entities.Requests
{
    public class ReadOfertasActivasFiltroEgresadoRequest : IRequest<IEnumerable<ReadOfertasActivasFiltroEgresadoResponse>>
    {
        public int idUsuarioEgresado { get; set; }
    }
}
