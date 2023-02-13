using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Docente
{
    public class ReadOfertasRevisionDocenteHandler : IRequestHandler<ReadOfertasRevisionDocenteRequest, List<ReadOfertasRevisionDocenteResponse>>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public ReadOfertasRevisionDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<List<ReadOfertasRevisionDocenteResponse>> Handle(ReadOfertasRevisionDocenteRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadOfertasRevisionDocenteResponse> listOfertasRevision = await this.cuentaDocenteService.readOfertasRevisionDocente(request);
            return listOfertasRevision.ToList();
        }
    }
}
