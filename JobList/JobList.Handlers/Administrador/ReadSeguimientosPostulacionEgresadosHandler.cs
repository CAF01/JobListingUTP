namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    public class ReadSeguimientosPostulacionEgresadosHandler : IRequestHandler<ReadSeguimientosPostulacionEgresadosRequest, List<ReadSeguimientosPostulacionEgresadosResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadSeguimientosPostulacionEgresadosHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de seguimientos de postulaciones de todos los egresados
        public async Task<List<ReadSeguimientosPostulacionEgresadosResponse>> Handle(ReadSeguimientosPostulacionEgresadosRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadSeguimientosPostulacionEgresadosResponse> listSeguimientos = await this.cuentaAdministradorService.readSeguimientosPostulacionEgresados();
            return listSeguimientos.ToList();
        }
    }
}
