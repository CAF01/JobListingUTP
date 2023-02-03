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
    public class ReadOfertasPublicadasEmpresaHandler : IRequestHandler<ReadOfertasPublicadasEmpresaRequest, List<OfertaPublicadaEmpresa>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadOfertasPublicadasEmpresaHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        //  Listado de ofertas publicadas por una empreas
        public async Task<List<OfertaPublicadaEmpresa>> Handle(ReadOfertasPublicadasEmpresaRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<OfertaPublicadaEmpresa> listOfertasPublicadasEmpresa = await this.cuentaAdministradorService.readOfertasPublicadasEmpresa(request);
            return listOfertasPublicadasEmpresa.ToList();
        }
    }
}
