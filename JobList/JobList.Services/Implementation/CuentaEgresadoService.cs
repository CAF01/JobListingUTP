namespace JobList.Services.Implementation
{
    using JobList.Entities.Requests;
    using JobList.Framework;
    using JobList.Repositories.Service;
    using JobList.Services.Service;

    public class CuentaEgresadoService : ICuentaEgresadoService
    {
        private readonly ICuentaEgresadoRepository cuentaEgresadoRepository;

        public CuentaEgresadoService(ICuentaEgresadoRepository cuentaEgresadoRepository)
        {
            this.cuentaEgresadoRepository = cuentaEgresadoRepository;
        }

        public async Task<bool> addConocimientoEgresado(insertConocimientoEgresadoRequest request)
        {
            return await this.cuentaEgresadoRepository.addConocimientoEgresado(request);
        }

        public async Task<bool> addEgresado(insertEgresadoRequest request)
        {
            request.password=PasswordEncryptor.GetMD5(request.password);
            return await this.cuentaEgresadoRepository.addEgresado(request);
        }

        public async Task<bool> addHabilidadEgresado(insertHabilidadEgresadoRequest request)
        {
            return await this.cuentaEgresadoRepository.addHabilidadEgresado(request);
        }
    }
}
