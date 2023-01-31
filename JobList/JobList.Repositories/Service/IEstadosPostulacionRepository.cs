using JobList.Entities.Requests;

namespace JobList.Repositories.Service
{
    public interface IEstadosPostulacionRepository
    {
        public Task<int> addEstadoPostulacion(InsertEstadoPostulacionRequest request);
    }
}
