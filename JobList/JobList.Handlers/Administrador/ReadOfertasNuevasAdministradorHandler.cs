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
    public class ReadOfertasNuevasAdministradorHandler : IRequestHandler<ReadOfertasNuevasAdministradorRequest, List<OfertaNuevaAdministrador>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadOfertasNuevasAdministradorHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de ofertas nuevas, esperando a ser validadas por el administrador
        public async Task<List<OfertaNuevaAdministrador>> Handle(ReadOfertasNuevasAdministradorRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<OfertaNuevaAdministrador> listOfertasNuevasAdministardor = await this.cuentaAdministradorService.readOfertasNuevasAdministrador();
            return listOfertasNuevasAdministardor.ToList();
        }
    }
}
