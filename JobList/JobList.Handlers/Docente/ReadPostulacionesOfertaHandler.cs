using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Docente
{
    public class ReadPostulacionesOfertaHandler : IRequestHandler<ReadPostulacionesOfertaRequest, List<ReadPostulacionesOfertaResponse>>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public ReadPostulacionesOfertaHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<List<ReadPostulacionesOfertaResponse>> Handle(ReadPostulacionesOfertaRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadPostulacionesOfertaResponse> listPostulaciones = await this.cuentaDocenteService.readPostulacionesOferta(request);
            return listPostulaciones.ToList();
        }
    }
}
