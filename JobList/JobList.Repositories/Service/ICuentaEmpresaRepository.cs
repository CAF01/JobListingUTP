namespace JobList.Repositories.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;

    public interface ICuentaEmpresaRepository
    {
        public Task<EmpresaInfo> findEmpresa(LoginEmpresaRequest userLogin);
        public Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoRequest request);
    }
}
