namespace JobList.Services.Implementation
{
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Services.Service;
    using System.Threading.Tasks;

    public class ConocimientosService : IConocimientosService
    {
        private readonly IConocimientosRepository conocimientosRepository;

        public ConocimientosService(IConocimientosRepository conocimientosRepository)
        {
            this.conocimientosRepository = conocimientosRepository;
        }

        public async Task<bool> addConocimiento(insertConocimientoRequest request)
        {
            return await this.conocimientosRepository.addConocimiento(request);
        }

        public async Task<bool> deleteConocimiento(deleteConocimientoRequest request)
        {
            return await this.conocimientosRepository.deleteConocimiento(request);
        }

        public async Task<bool> updateConocimiento(updateConocimientoRequest request)
        {
            return await this.conocimientosRepository.updateConocimiento(request);
        }
    }
}
