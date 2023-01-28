using JobList.Entities.Requests;

namespace JobList.Repositories.Service
{
    public interface ICuentaDocenteRepository
    {
        public Task<bool> addDocente(insertDocenteRequest request);
    }
}
