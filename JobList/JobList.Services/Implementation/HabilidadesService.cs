namespace JobList.Services.Implementation
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Services.Service;
    using System.Threading.Tasks;

    public class HabilidadesService : IHabilidadesService
    {
        private readonly IHabilidadesRepository habilidadesRepository;

        // Constrcutor
        public HabilidadesService(IHabilidadesRepository habilidadesRepository)
        {
            this.habilidadesRepository = habilidadesRepository;
        }

        // Insertar una habilidad
        public async Task<int> addHabilidad(InsertHabilidadRequest request)
        {
            return await this.habilidadesRepository.addHabilidad(request);
        }

        // Eliminar una habilidad
        public async Task<bool> deleteHabilidad(DeleteHabilidadRequest request)
        {
            return await this.habilidadesRepository.deleteHabilidad(request);
        }

        // Actualizar una habilidad
        public async Task<bool> updateHabilidad(UpdateHabilidadRequest request)
        {
            return await this.habilidadesRepository.updateHabilidad(request);
        }

        // Devolver lista de habilidades
        public async Task<IEnumerable<ReadHabilidadesResponse>> readHabilidades()
        {
            return await this.habilidadesRepository.readHabilidades();
        }
    }
}
