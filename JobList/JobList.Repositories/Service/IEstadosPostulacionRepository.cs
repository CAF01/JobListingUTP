using JobList.Entities.Requests;

namespace JobList.Repositories.Service
{
    public interface IEstadosPostulacionRepository
    {
        public Task<bool> addEstadoPostulacion(insertEstadoPostulacionRequest request);
    }
}
