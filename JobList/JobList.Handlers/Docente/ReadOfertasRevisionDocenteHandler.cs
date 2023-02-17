using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Docente
{
    public class ReadOfertasRevisionDocenteHandler : IRequestHandler<ReadOfertasRevisionDocenteRequest, PaginationListResponse<ReadOfertasRevisionDocenteResponse>>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public ReadOfertasRevisionDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<PaginationListResponse<ReadOfertasRevisionDocenteResponse>> Handle(ReadOfertasRevisionDocenteRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaDocenteService.readOfertasRevisionDocente(request);
        }
    }
}
