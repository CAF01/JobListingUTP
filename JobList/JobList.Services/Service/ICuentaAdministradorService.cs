namespace JobList.Services.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;

    public interface ICuentaAdministradorService
    {
        public Task<bool> addAdministrador(insertAdminRequest request);
        public Task<adminInfo> loginAdministradorConToken(loginAdminRequest userLogin);
    }
}
