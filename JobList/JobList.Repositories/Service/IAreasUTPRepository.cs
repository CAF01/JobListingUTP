namespace JobList.Repositories.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;

    public interface IAreasUTPRepository
    {
        public Task<int> addDivision(InsertDivisionRequest request);
        public Task<int> addArea(InsertAreaRequest request);
        public Task<IEnumerable<ReadDivisionesResponse>> readDivisiones();
        public Task<IEnumerable<ReadAreasDivisionResponse>> readAreasDivision(ReadAreasDivisionRequest request);
    }
}
