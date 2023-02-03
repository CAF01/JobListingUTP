namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;

    public interface ICuentaDocenteService
    {
        public Task<int> addDocente(InsertDocenteRequest request);
        public Task<LoginDocenteResponse> loginDocenteConToken(LoginDocenteRequest userLogin);
    }
}
