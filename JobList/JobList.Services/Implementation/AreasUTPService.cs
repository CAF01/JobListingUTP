namespace JobList.Services.Implementation
{
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Services.Service;
    public class AreasUTPService : IAreasUTPService
    {
        private readonly IAreasUTPRepository areasUTPRepository;

        public AreasUTPService(IAreasUTPRepository areasUTPRepository)
        {
            this.areasUTPRepository = areasUTPRepository;
        }

        public async Task<bool> addArea(insertAreaRequest request)
        {
            return await this.areasUTPRepository.addArea(request);
        }

        public async Task<bool> addDivision(insertDivisionRequest request)
        {
            return await this.areasUTPRepository.addDivision(request);
        }
    }
}
