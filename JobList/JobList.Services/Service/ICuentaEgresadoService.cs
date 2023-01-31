using JobList.Entities.Requests;

namespace JobList.Services.Service
{
    public interface ICuentaEgresadoService
    {
        public Task<int> addEgresado(InsertEgresadoRequest request);
        public Task<int> addConocimientoEgresado(InsertConocimientoEgresadoRequest request);
        public Task<int> addHabilidadEgresado(InsertHabilidadEgresadoRequest request);
    }
}
