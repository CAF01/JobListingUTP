namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class ReadOfertasPublicadasEmpresaHandler : IRequestHandler<ReadOfertasPublicadasEmpresaRequest, PaginationListResponse<ReadOfertasPublicadasEmpresaResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadOfertasPublicadasEmpresaHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        //  Listado de ofertas publicadas por una empreas
        public async Task<PaginationListResponse<ReadOfertasPublicadasEmpresaResponse>> Handle(ReadOfertasPublicadasEmpresaRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaAdministradorService.readOfertasPublicadasEmpresa(request);
        }
    }
}
