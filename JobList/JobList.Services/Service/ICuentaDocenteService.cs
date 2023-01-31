namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    public interface ICuentaDocenteService
    {
        public Task<int> addDocente(InsertDocenteRequest request);
    }
}
