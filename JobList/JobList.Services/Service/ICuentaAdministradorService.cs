namespace JobList.Services.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;

    public interface ICuentaAdministradorService
    {
        public Task<int> addAdministrador(InsertAdminRequest request);
        public Task<AdminInfo> loginAdministradorConToken(LoginAdminRequest userLogin);
    }
}
