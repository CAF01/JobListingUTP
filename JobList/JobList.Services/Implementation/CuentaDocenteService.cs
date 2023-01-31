namespace JobList.Services.Implementation
{
    using JobList.Entities.Requests;
    using JobList.Framework;
    using JobList.Repositories.Service;
    using JobList.Services.Service;
    using System.Threading.Tasks;

    public class CuentaDocenteService : ICuentaDocenteService
    {
        private readonly ICuentaDocenteRepository cuentaDocenteRepository;

        public CuentaDocenteService(ICuentaDocenteRepository cuentaDocenteRepository)
        {
            this.cuentaDocenteRepository = cuentaDocenteRepository;
        }
        public async Task<int> addDocente(InsertDocenteRequest request)
        {
            request.password = PasswordEncryptor.GetMD5(request.password);
            return await this.cuentaDocenteRepository.addDocente(request);
        }
    }
}
