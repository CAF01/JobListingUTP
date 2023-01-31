using JobList.Entities.Requests;

namespace JobList.Repositories.Service
{
    public interface IConocimientosRepository
    {
        public Task<int> addConocimiento(InsertConocimientoRequest request);
        public Task<bool> updateConocimiento(UpdateConocimientoRequest request);
        public Task<bool> deleteConocimiento(DeleteConocimientoRequest request);
    }
}
