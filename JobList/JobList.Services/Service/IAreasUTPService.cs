namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    public interface IAreasUTPService
    {
        public Task<int> addDivision(InsertDivisionRequest request);
        public Task<int> addArea(InsertAreaRequest request);
    }
}
