namespace JobList.Services.Implementation
{
    using JobList.Entities.Requests;
    using JobList.Framework;
    using JobList.Repositories.Service;
    using JobList.Services.Service;
    using System.Threading.Tasks;

    public class CuentaAdministradorService : ICuentaAdministradorService
    {
        private readonly ICuentaAdministradorRepository cuentaAdministradorRepository;

        public CuentaAdministradorService(ICuentaAdministradorRepository cuentaAdministradorRepository)
        {
            this.cuentaAdministradorRepository = cuentaAdministradorRepository;
        }
        public async Task<bool> addAdministrador(insertAdminRequest request)
        {
            request.password = PasswordEncryptor.GetMD5(request.password);

            return await this.cuentaAdministradorRepository.addAdministrador(request);
        }
    }
}
