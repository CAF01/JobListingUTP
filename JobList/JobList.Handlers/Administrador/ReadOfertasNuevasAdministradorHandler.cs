namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;

    public class ReadOfertasNuevasAdministradorHandler : IRequestHandler<ReadOfertasNuevasAdministradorRequest, PaginationListResponse<ReadOfertasNuevasAdministradorResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadOfertasNuevasAdministradorHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de ofertas nuevas, esperando a ser validadas por el administrador
        public async Task<PaginationListResponse<ReadOfertasNuevasAdministradorResponse>> Handle(ReadOfertasNuevasAdministradorRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaAdministradorService.readOfertasNuevasAdministrador();
        }
    }
}
