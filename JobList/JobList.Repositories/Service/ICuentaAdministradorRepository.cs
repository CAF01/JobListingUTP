using JobList.Entities.Models;
using JobList.Entities.Requests;

namespace JobList.Repositories.Service
{
    public interface ICuentaAdministradorRepository
    {
        public Task<int> addAdministrador(InsertAdminRequest request);
        public Task<AdminInfo> findAdministrador(LoginAdminRequest userLogin);
    }
}
