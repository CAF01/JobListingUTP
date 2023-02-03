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
    public class ReadOfertasActivasAdministradorHandler : IRequestHandler<ReadOfertasActivasAdministradorRequest, List<OfertaActivaAdministrador>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadOfertasActivasAdministradorHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de ofertas activas (de todos los usuarios)
        public async Task<List<OfertaActivaAdministrador>> Handle(ReadOfertasActivasAdministradorRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<OfertaActivaAdministrador> listOfertasActivasAdministardor = await this.cuentaAdministradorService.readOfertasActivasAdministrador();
            return listOfertasActivasAdministardor.ToList();
        }
    }
}
