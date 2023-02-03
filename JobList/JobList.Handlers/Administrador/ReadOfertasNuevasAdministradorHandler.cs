namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;

    public class ReadOfertasNuevasAdministradorHandler : IRequestHandler<ReadOfertasNuevasAdministradorRequest, List<ReadOfertasNuevasAdministradorResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadOfertasNuevasAdministradorHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de ofertas nuevas, esperando a ser validadas por el administrador
        public async Task<List<ReadOfertasNuevasAdministradorResponse>> Handle(ReadOfertasNuevasAdministradorRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadOfertasNuevasAdministradorResponse> listOfertasNuevasAdministardor = await this.cuentaAdministradorService.readOfertasNuevasAdministrador();
            return listOfertasNuevasAdministardor.ToList();
        }
    }
}
