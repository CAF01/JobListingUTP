using JobList.Entities.Models;
using JobList.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Repositories.Service
{
    public interface ICuentaEmpresaRepository
    {
        public Task<EmpresaInfo> findEmpresa(LoginEmpresaRequest userLogin);
    }
}
