namespace JobList.Repositories.Service
{
    using JobList.Entities.Requests;

    public interface ICuentaEgresadoRepository
    {
        public Task<int> addEgresado(InsertEgresadoRequest request);
        public Task<int> addConocimientoEgresado(InsertConocimientoEgresadoRequest request);
        public Task<int> addHabilidadEgresado(InsertHabilidadEgresadoRequest request);
    }
}
