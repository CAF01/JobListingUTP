namespace JobList.Services.Implementation
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Repositories.Service;
    using JobList.Services.Service;
    public class AreasUTPService : IAreasUTPService
    {
        private readonly IAreasUTPRepository areasUTPRepository;

        // Constructor
        public AreasUTPService(IAreasUTPRepository areasUTPRepository)
        {
            this.areasUTPRepository = areasUTPRepository;
        }

        // Insertar un área
        public async Task<int> addArea(InsertAreaRequest request)
        {
            return await this.areasUTPRepository.addArea(request);
        }

        // Insertar una división
        public async Task<int> addDivision(InsertDivisionRequest request)
        {
            return await this.areasUTPRepository.addDivision(request);
        }

        // Devolver lista de divisiones
        public async Task<IEnumerable<ReadDivisionesResponse>> readDivisiones()
        {
            return await this.areasUTPRepository.readDivisiones();
        }

        // Devolver lista de áreas de una división
        public async Task<IEnumerable<ReadAreasDivisionResponse>> readAreasDivision(ReadAreasDivisionRequest request)
        {
            return await this.areasUTPRepository.readAreasDivision(request);
        }
    }
}
