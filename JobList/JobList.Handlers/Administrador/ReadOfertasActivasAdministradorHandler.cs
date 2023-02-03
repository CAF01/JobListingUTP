namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    public class ReadOfertasActivasAdministradorHandler : IRequestHandler<ReadOfertasActivasAdministradorRequest, List<ReadOfertasActivasAdministradorResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadOfertasActivasAdministradorHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de ofertas activas (de todos los usuarios)
        public async Task<List<ReadOfertasActivasAdministradorResponse>> Handle(ReadOfertasActivasAdministradorRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadOfertasActivasAdministradorResponse> listOfertasActivasAdministardor = await this.cuentaAdministradorService.readOfertasActivasAdministrador();
            return listOfertasActivasAdministardor.ToList();
        }
    }
}
