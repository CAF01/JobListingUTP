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

        public async Task<int> addConocimientoEgresado(InsertConocimientoEgresadoRequest request)
        {
            return await this.cuentaEgresadoRepository.addConocimientoEgresado(request);
        }

        public async Task<int> addEgresado(InsertEgresadoRequest request)
        {
            request.password=PasswordEncryptor.GetMD5(request.password);
            return await this.cuentaEgresadoRepository.addEgresado(request);
        }

        public async Task<int> addHabilidadEgresado(InsertHabilidadEgresadoRequest request)
        {
            return await this.cuentaEgresadoRepository.addHabilidadEgresado(request);
        }
    }
}
