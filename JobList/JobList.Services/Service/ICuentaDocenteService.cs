namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    public interface ICuentaDocenteService
    {
        public Task<bool> addDocente(insertDocenteRequest request);
    }
}
