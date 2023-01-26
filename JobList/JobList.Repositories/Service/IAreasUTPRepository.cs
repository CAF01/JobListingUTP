namespace JobList.Repositories.Service
{
    using JobList.Entities.Requests;
    public interface IAreasUTPRepository
    {
        public Task<bool> addDivision(insertDivisionRequest request);
        public Task<bool> addArea(insertAreaRequest request);
    }
}
