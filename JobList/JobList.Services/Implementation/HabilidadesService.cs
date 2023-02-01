namespace JobList.Services.Implementation
{
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Services.Service;
    using System.Threading.Tasks;

    public class HabilidadesService : IHabilidadesService
    {
        private readonly IHabilidadesRepository habilidadesRepository;

        public HabilidadesService(IHabilidadesRepository habilidadesRepository)
        {
            this.habilidadesRepository = habilidadesRepository;
        }
        public async Task<int> addHabilidad(InsertHabilidadRequest request)
        {
            return await this.habilidadesRepository.addHabilidad(request);
        }

        public async Task<bool> deleteHabilidad(DeleteHabilidadRequest request)
        {
            return await this.habilidadesRepository.deleteHabilidad(request);
        }

        public async Task<bool> updateHabilidad(UpdateHabilidadRequest request)
        {
            return await this.habilidadesRepository.updateHabilidad(request);
        }
    }
}
