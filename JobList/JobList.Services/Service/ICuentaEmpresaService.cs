namespace JobList.Services.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    public interface ICuentaEmpresaService
    {
        public Task<EmpresaInfo> loginEmpresaConToken(LoginEmpresaRequest userLogin);
        public Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoRequest request);
    }
}
