namespace JobList.Repositories.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    public interface IHabilidadesRepository
    {
        public Task<int> addHabilidad(InsertHabilidadRequest request);
        public Task<bool> updateHabilidad(UpdateHabilidadRequest request);
        public Task<bool> deleteHabilidad(DeleteHabilidadRequest request);
        public Task<IEnumerable<Habilidad>> readHabilidades();
    }
}
