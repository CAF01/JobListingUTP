using JobList.Entities.Requests;
using JobList.Entities.Responses;

namespace JobList.Services.Service
{
    public interface IConocimientosService
    {
        public Task<int> addConocimiento(InsertConocimientoRequest request); 
        public Task<bool> updateConocimiento(UpdateConocimientoRequest request);
        public Task<bool> deleteConocimiento(DeleteConocimientoRequest request);
        public Task<IEnumerable<ReadConocimientosResponse>> readConocimientos();
    }
}
