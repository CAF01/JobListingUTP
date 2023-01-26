namespace JobList.Services.Service
{
    using JobList.Entities.Requests;

    public interface ICuentaAdministradorService
    {
        public Task<bool> addAdministrador(insertAdminRequest request);
    }
}
