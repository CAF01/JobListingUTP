using JobList.Entities.Responses;
using MediatR;

namespace JobList.Entities.Requests
{
    public class UpdateEstadoPostulacionRequest : IRequest<UpdateEstadoPostulacionResponse>
    {
        public int idPostulacion { get; set; }
        public int accion { get; set; }
    }
}
