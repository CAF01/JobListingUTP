using JobList.Entities.Requests;
using JobList.Entities.Responses;

namespace JobList.Repositories.Service
{
    public interface ICuentaDocenteRepository
    {
        public Task<int> addDocente(InsertDocenteRequest request);
        public Task<LoginDocenteResponse> findDocente(LoginDocenteRequest userLogin);
    }
}
