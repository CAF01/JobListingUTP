namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class ReadEmpresasAfiliadasHandler : IRequestHandler<ReadEmpresasAfiliadasRequest, PaginationListResponse<ReadEmpresasAfiliadasResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadEmpresasAfiliadasHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de empresas afiliadas
        public async Task<PaginationListResponse<ReadEmpresasAfiliadasResponse>> Handle(ReadEmpresasAfiliadasRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaAdministradorService.readEmpresasAfiliadas();
        }
    }
}
