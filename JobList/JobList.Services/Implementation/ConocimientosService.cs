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

        public async Task<int> addConocimiento(InsertConocimientoRequest request)
        {
            return await this.conocimientosRepository.addConocimiento(request);
        }

        public async Task<bool> deleteConocimiento(DeleteConocimientoRequest request)
        {
            return await this.conocimientosRepository.deleteConocimiento(request);
        }

        public async Task<bool> updateConocimiento(UpdateConocimientoRequest request)
        {
            return await this.conocimientosRepository.updateConocimiento(request);
        }
    }
}
