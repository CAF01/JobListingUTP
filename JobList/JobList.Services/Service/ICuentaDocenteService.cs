namespace JobList.Services.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    public interface ICuentaDocenteService
    {
        public Task<int> addDocente(InsertDocenteRequest request);
        public Task<DocenteInfo> loginDocenteConToken(LoginDocenteRequest userLogin);
    }
}
