namespace JobList.Services.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    public interface IAreasUTPService
    {
        public Task<int> addDivision(InsertDivisionRequest request);
        public Task<int> addArea(InsertAreaRequest request);
        public Task<IEnumerable<Division>> readDivisiones();
        public Task<IEnumerable<Area>> readAreasDivision(readAreasDivisionRequest request);
    }
}
