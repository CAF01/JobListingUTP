using JobList.Entities.Requests;

namespace JobList.Repositories.Service
{
    public interface IConocimientosRepository
    {
        public Task<bool> addConocimiento(insertConocimientoRequest request);
        public Task<bool> updateConocimiento(updateConocimientoRequest request);
        public Task<bool> deleteConocimiento(deleteConocimientoRequest request);
    }
}
