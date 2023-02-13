namespace JobList.Services.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    public interface ICuentaEmpresaService
    {
        public Task<EmpresaInfo> loginEmpresaConToken(LoginEmpresaRequest userLogin);
        public Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoRequest request);
        public Task<InsertEmpresaResponse> insertCuentaEmpresa(InsertEmpresaRequest request);
        public Task<UpdateEmpresaDatosResponse> updateDatosEmpresa(UpdateEmpresaDatosRequest request);
        public Task<IEnumerable<GetEmpresaListaOfertasActivasResponse>> getOfertasActivasEmpresa(GetEmpresaListaOfertasActivasRequest request);
        public Task<bool> SetStatusOfertaActivaBorrar(DeleteOfertaTrabajoActivaRequest request);
        public Task<IEnumerable<GetEmpresaOfertasRevisionResponse>> getOfertasRevisionEmpresa(GetEmpresaOfertasRevisionRequest request);
        public Task<IEnumerable<GetEmpresaOfertasHistorialResponse>> getOfertasHistorialEmpresa(GetEmpresaOfertasHistorialRequest request);
        public Task<GetOfertasTrabajoDetalleResponse> GetDetallesOferta(GetOfertasTrabajoDetalleRequest request);
    }
}
