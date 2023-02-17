using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Docente
{
    public class ReadOfertasActivasDocenteHandler : IRequestHandler<ReadOfertasActivasDocenteRequest, PaginationListResponse<ReadOfertasActivasDocenteResponse>>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public ReadOfertasActivasDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<PaginationListResponse<ReadOfertasActivasDocenteResponse>> Handle(ReadOfertasActivasDocenteRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaDocenteService.readOfertasActivasDocente(request);
        }
    }
}
