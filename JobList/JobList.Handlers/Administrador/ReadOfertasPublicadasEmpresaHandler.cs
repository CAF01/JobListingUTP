namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    public class ReadOfertasPublicadasEmpresaHandler : IRequestHandler<ReadOfertasPublicadasEmpresaRequest, List<ReadOfertasPublicadasEmpresaResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadOfertasPublicadasEmpresaHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        //  Listado de ofertas publicadas por una empreas
        public async Task<List<ReadOfertasPublicadasEmpresaResponse>> Handle(ReadOfertasPublicadasEmpresaRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadOfertasPublicadasEmpresaResponse> listOfertasPublicadasEmpresa = await this.cuentaAdministradorService.readOfertasPublicadasEmpresa(request);
            return listOfertasPublicadasEmpresa.ToList();
        }
    }
}
