using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Docente
{
    public class ReadOfertasActivasDocenteHandler : IRequestHandler<ReadOfertasActivasDocenteRequest, IEnumerable<ReadOfertasActivasDocenteResponse>>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public ReadOfertasActivasDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<IEnumerable<ReadOfertasActivasDocenteResponse>> Handle(ReadOfertasActivasDocenteRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaDocenteService.readOfertasActivasDocente(request);
        }
    }
}
