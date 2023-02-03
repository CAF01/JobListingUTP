namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    public class ReadEmpresasAfiliadasHandler : IRequestHandler<ReadEmpresasAfiliadasRequest, List<ReadEmpresasAfiliadasResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadEmpresasAfiliadasHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de empresas afiliadas
        public async Task<List<ReadEmpresasAfiliadasResponse>> Handle(ReadEmpresasAfiliadasRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadEmpresasAfiliadasResponse> listEmpresasAfiliadas = await this.cuentaAdministradorService.readEmpresasAfiliadas();
            return listEmpresasAfiliadas.ToList();
        }
    }
}
