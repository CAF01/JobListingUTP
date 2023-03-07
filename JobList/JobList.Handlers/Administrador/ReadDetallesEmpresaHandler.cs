namespace JobList.Handlers.Administrador
{
    using JobList.Services.Service;
    using MediatR;
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    public class ReadDetallesEmpresaHandler : IRequestHandler<ReadDetallesEmpresaRequest, ReadDetallesEmpresaResponse>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadDetallesEmpresaHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Consultar detalles de una empresa
        public async Task<ReadDetallesEmpresaResponse> Handle(ReadDetallesEmpresaRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaAdministradorService.readDetallesEmpresa(request);
        }
    }
}
