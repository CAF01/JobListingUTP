using JobList.Entities.Requests;

namespace JobList.Services.Service
{
    public interface ICuentaEgresadoService
    {
        public Task<bool> addEgresado(insertEgresadoRequest request);
        public Task<bool> addConocimientoEgresado(insertConocimientoEgresadoRequest request);
        public Task<bool> addHabilidadEgresado(insertHabilidadEgresadoRequest request);
    }
}
