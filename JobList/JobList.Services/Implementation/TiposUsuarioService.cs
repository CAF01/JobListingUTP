using JobList.Entities.Models;
using JobList.Repositories.Service;
using JobList.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Services.Implementation
{
    public class TiposUsuarioService : ITiposUsuarioService
    {
        private readonly ITiposUsuarioRepository tiposUsuarioRepository;

        public TiposUsuarioService(ITiposUsuarioRepository tiposUsuarioRepository)
        {
            this.tiposUsuarioRepository = tiposUsuarioRepository;
        }   

        public async Task<IEnumerable<ReadTiposUsuarioResponse>> readTiposUsuario()
        {
            return await this.tiposUsuarioRepository.readTiposUsuario();
        }

        
    }
}
