using JobList.Entities.Requests;

namespace JobList.Services.Service
{
    public interface IConocimientosService
    {
        public Task<bool> addConocimiento(insertConocimientoRequest request); 
        public Task<bool> updateConocimiento(updateConocimientoRequest request);
        public Task<bool> deleteConocimiento(deleteConocimientoRequest request);
    }
}
