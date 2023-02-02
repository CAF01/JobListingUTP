using JobList.Entities.Models;
using JobList.Entities.Requests;
using JobList.Services.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Handlers.Catalogs
{
    public class ReadTiposUsuarioHandler : IRequestHandler<readTiposUsuarioRequest, List<TipoUsuario>>
    {
        private readonly ITiposUsuarioService tiposUsuarioService;

        public ReadTiposUsuarioHandler(ITiposUsuarioService tiposUsuarioService)
        {
            this.tiposUsuarioService = tiposUsuarioService;
        }

        public async Task<List<TipoUsuario>> Handle(readTiposUsuarioRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<TipoUsuario> listTipoUsuario = await this.tiposUsuarioService.readTiposUsuario();
            return listTipoUsuario.ToList();
        }
    }
}
