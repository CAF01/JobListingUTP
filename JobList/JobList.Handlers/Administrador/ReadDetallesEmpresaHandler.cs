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
    public class ReadDetallesEmpresaHandler : IRequestHandler<ReadDetallesEmpresaRequest, List<ReadDetallesEmpresaResponse>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadDetallesEmpresaHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Consultar detalles de una empresa
        public async Task<List<ReadDetallesEmpresaResponse>> Handle(ReadDetallesEmpresaRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadDetallesEmpresaResponse> listDetallesEmpresa = await this.cuentaAdministradorService.readDetallesEmpresa(request);
            return listDetallesEmpresa.ToList();
        }
    }
}
