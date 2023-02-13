using JobList.Entities.Responses;
using MediatR;

namespace JobList.Entities.Requests
{
    public class ReadPostulacionesOfertaRequest : IRequest<List<ReadPostulacionesOfertaResponse>>
    {
        public int idOferta { get; set; }
    }
}
