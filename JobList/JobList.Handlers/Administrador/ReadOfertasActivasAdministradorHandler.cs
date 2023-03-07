namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class ReadOfertasActivasAdministradorHandler : IRequestHandler<ReadOfertasActivasAdministradorRequest, PaginationListResponse<ReadOfertasActivasAdministradorResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadOfertasActivasAdministradorHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de ofertas activas (de todos los usuarios)
        public async Task<PaginationListResponse<ReadOfertasActivasAdministradorResponse>> Handle(ReadOfertasActivasAdministradorRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaAdministradorService.readOfertasActivasAdministrador();
        }
    }
}
