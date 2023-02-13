using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Docente
{
    public class ReadOfertasActivasDocenteHandler : IRequestHandler<ReadOfertasActivasDocenteRequest, List<ReadOfertasActivasDocenteResponse>>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public ReadOfertasActivasDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<List<ReadOfertasActivasDocenteResponse>> Handle(ReadOfertasActivasDocenteRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadOfertasActivasDocenteResponse> listOfertasActivas = await this.cuentaDocenteService.readOfertasActivasDocente(request);
            return listOfertasActivas.ToList();
        }
    }
}
