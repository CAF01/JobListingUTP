using JobList.Entities.Requests;

namespace JobList.Repositories.Service
{
    public interface ICuentaDocenteRepository
    {
        public Task<int> addDocente(InsertDocenteRequest request);
    }
}
