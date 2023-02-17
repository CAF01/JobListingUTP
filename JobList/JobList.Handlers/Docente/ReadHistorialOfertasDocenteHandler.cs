namespace JobList.Handlers.Docente
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;

    public class ReadHistorialOfertasDocenteHandler : IRequestHandler<ReadHistorialOfertasDocenteRequest, PaginationListResponse<ReadHistorialOfertasDocenteResponse>>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public ReadHistorialOfertasDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<PaginationListResponse<ReadHistorialOfertasDocenteResponse>> Handle(ReadHistorialOfertasDocenteRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaDocenteService.readHistorialOfertasDocente(request);
        }
    }
}
