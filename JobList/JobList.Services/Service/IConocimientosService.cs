using JobList.Entities.Models;
using JobList.Entities.Requests;

namespace JobList.Services.Service
{
    public interface IConocimientosService
    {
        public Task<int> addConocimiento(InsertConocimientoRequest request); 
        public Task<bool> updateConocimiento(UpdateConocimientoRequest request);
        public Task<bool> deleteConocimiento(DeleteConocimientoRequest request);
        public Task<IEnumerable<Conocimiento>> readConocimientos();
    }
}
