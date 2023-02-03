using JobList.Entities.Models;
using JobList.Entities.Requests;
using JobList.Services.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Handlers.Administrador
{
    public class ReadSeguimientosPostulacionEgresadosHandler : IRequestHandler<ReadSeguimientosPostulacionEgresadosRequest, List<SeguimientoPostulacionEgresado>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadSeguimientosPostulacionEgresadosHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de seguimientos de postulaciones de todos los egresados
        public async Task<List<SeguimientoPostulacionEgresado>> Handle(ReadSeguimientosPostulacionEgresadosRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<SeguimientoPostulacionEgresado> listSeguimientos = await this.cuentaAdministradorService.readSeguimientosPostulacionEgresados();
            return listSeguimientos.ToList();
        }
    }
}
