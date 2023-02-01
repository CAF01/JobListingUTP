namespace JobList.Repositories.Service
{
    using JobList.Entities.Requests;
    public interface IAreasUTPRepository
    {
        public Task<int> addDivision(InsertDivisionRequest request);
        public Task<int> addArea(InsertAreaRequest request);
    }
}
