using JobList.Entities.Responses;
using MediatR;

namespace JobList.Entities.Requests
{
    public class DeleteOfertaActivaDocenteRequest : IRequest<DeleteOfertaActivaDocenteResponse>
    {
        public int idOferta { get; set; }
    }
}
