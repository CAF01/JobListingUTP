namespace JobList.Repositories.Service
{
    using JobList.Entities.Requests;
    public interface IHabilidadesRepository
    {
        public Task<bool> addHabilidad(insertHabilidadRequest request);
        public Task<bool> updateHabilidad(updateHabilidadRequest request);
        public Task<bool> deleteHabilidad(deleteHabilidadRequest request);
    }
}
