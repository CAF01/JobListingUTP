using JobList.Entities.Models;
using JobList.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Services.Service
{
    public interface ICuentaEmpresaService
    {
        public Task<EmpresaInfo> loginEmpresaConToken(LoginEmpresaRequest userLogin);
    }
}
