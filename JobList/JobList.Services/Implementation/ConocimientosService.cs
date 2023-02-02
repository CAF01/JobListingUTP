namespace JobList.Services.Implementation
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Services.Service;
    using System.Threading.Tasks;

    public class ConocimientosService : IConocimientosService
    {
        private readonly IConocimientosRepository conocimientosRepository;

        // Constructor
        public ConocimientosService(IConocimientosRepository conocimientosRepository)
        {
            this.conocimientosRepository = conocimientosRepository;
        }

        // Insertar un conocimiento
        public async Task<int> addConocimiento(InsertConocimientoRequest request)
        {
            return await this.conocimientosRepository.addConocimiento(request);
        }

        // Eliminar un conocimiento
        public async Task<bool> deleteConocimiento(DeleteConocimientoRequest request)
        {
            return await this.conocimientosRepository.deleteConocimiento(request);
        }

        // Actualizar un conocimiento
        public async Task<bool> updateConocimiento(UpdateConocimientoRequest request)
        {
            return await this.conocimientosRepository.updateConocimiento(request);
        }

        // Devolver lista de conocimientos
        public async Task<IEnumerable<Conocimiento>> readConocimientos()
        {
            return await this.conocimientosRepository.readConocimientos();
        }
    }
}
