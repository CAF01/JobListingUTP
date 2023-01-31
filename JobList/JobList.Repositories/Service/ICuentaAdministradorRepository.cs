using JobList.Entities.Models;
using JobList.Entities.Requests;

namespace JobList.Repositories.Service
{
    public interface ICuentaAdministradorRepository
    {
        public Task<bool> addAdministrador(insertAdminRequest request);
        public Task<adminInfo> findAdministrador(loginAdminRequest userLogin);
    }
}
