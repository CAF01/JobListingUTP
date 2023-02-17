using JobList.Entities.Responses;
using MediatR;

namespace JobList.Entities.Requests
{
    public class ReadDetallesOfertaRequest : IRequest<ReadDetallesOfertaResponse>
    {
        public int idOferta { get; set; }
    }
}
