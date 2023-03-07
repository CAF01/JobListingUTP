namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class ReadSeguimientosPostulacionEgresadosHandler : IRequestHandler<ReadSeguimientosPostulacionEgresadosRequest, PaginationListResponse<ReadSeguimientosPostulacionEgresadosResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadSeguimientosPostulacionEgresadosHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de seguimientos de postulaciones de todos los egresados
        public async Task<PaginationListResponse<ReadSeguimientosPostulacionEgresadosResponse>> Handle(ReadSeguimientosPostulacionEgresadosRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaAdministradorService.readSeguimientosPostulacionEgresados();
        }
    }
}
