namespace JobList.Repositories.Service
{
    using JobList.Entities.Requests;

    public interface ICuentaEgresadoRepository
    {
        public Task<bool> addEgresado(insertEgresadoRequest request);
        public Task<bool> addConocimientoEgresado(insertConocimientoEgresadoRequest request);
        public Task<bool> addHabilidadEgresado(insertHabilidadEgresadoRequest request);
    }
}
