namespace JobList.Repositories.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    public interface IAreasUTPRepository
    {
        public Task<int> addDivision(InsertDivisionRequest request);
        public Task<int> addArea(InsertAreaRequest request);
        public Task<IEnumerable<Division>> readDivisiones();
        public Task<IEnumerable<Area>> readAreasDivision(readAreasDivisionRequest request);
    }
}
