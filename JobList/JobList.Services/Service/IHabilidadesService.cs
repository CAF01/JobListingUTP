namespace JobList.Services.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    public interface IHabilidadesService
    {
        public Task<int> addHabilidad(InsertHabilidadRequest request);
        public Task<bool> updateHabilidad(UpdateHabilidadRequest request);
        public Task<bool> deleteHabilidad(DeleteHabilidadRequest request);
        public Task<IEnumerable<ReadHabilidadesResponse>> readHabilidades();
    }
}
