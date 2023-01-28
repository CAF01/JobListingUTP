namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    public interface IHabilidadesService
    {
        public Task<bool> addHabilidad(insertHabilidadRequest request);
        public Task<bool> updateHabilidad(updateHabilidadRequest request);
        public Task<bool> deleteHabilidad(deleteHabilidadRequest request);
    }
}
