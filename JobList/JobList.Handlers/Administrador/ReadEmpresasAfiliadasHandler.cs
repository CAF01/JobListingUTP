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
    public class ReadEmpresasAfiliadasHandler : IRequestHandler<ReadEmpresasAfiliadasRequest, List<EmpresaAfiliada>>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        // Constructor
        public ReadEmpresasAfiliadasHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }

        // Listado de empresas afiliadas
        public async Task<List<EmpresaAfiliada>> Handle(ReadEmpresasAfiliadasRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<EmpresaAfiliada> listEmpresasAfiliadas = await this.cuentaAdministradorService.readEmpresasAfiliadas();
            return listEmpresasAfiliadas.ToList();
        }
    }
}
