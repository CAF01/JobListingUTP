using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Repositories.Service;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Docente
{
    public class ReadHistorialOfertasDocenteHandler : IRequestHandler<ReadHistorialOfertasDocenteRequest, List<ReadHistorialOfertasDocenteResponse>>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public ReadHistorialOfertasDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<List<ReadHistorialOfertasDocenteResponse>> Handle(ReadHistorialOfertasDocenteRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadHistorialOfertasDocenteResponse> listHistorialOfertas = await this.cuentaDocenteService.readHistorialOfertasDocente(request);
            return listHistorialOfertas.ToList();
        }
    }
}
