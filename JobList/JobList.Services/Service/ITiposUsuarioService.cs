using JobList.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Services.Service
{
    public interface ITiposUsuarioService
    {
        public Task<IEnumerable<TipoUsuario>> readTiposUsuario();
    }
}
