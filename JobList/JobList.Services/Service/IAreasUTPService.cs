namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    public interface IAreasUTPService
    {
        public Task<bool> addDivision(insertDivisionRequest request);
        public Task<bool> addArea(insertAreaRequest request);
    }
}
