namespace JobList.Repositories.Service
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    public interface ICuentaDocenteRepository
    {
        public Task<int> addDocente(InsertDocenteRequest request);
        public Task<LoginDocenteResponse> findDocente(LoginDocenteRequest userLogin);
        public Task<PaginationListResponse<ReadHistorialOfertasDocenteResponse>> readHistorialOfertasDocente(ReadHistorialOfertasDocenteRequest request);
        public Task<PaginationListResponse<ReadOfertasRevisionDocenteResponse>> readOfertasRevisionDocente(ReadOfertasRevisionDocenteRequest request);
        public Task<PaginationListResponse<ReadOfertasActivasDocenteResponse>> readOfertasActivasDocente(ReadOfertasActivasDocenteRequest request);
        public Task<UpdatePasswordDocenteResponse> updatePassword(UpdatePasswordDocenteRequest request);
        public Task<bool> updateUltimoAccesoSistema(int idUsuario);
        public Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoExternaRequest request);
        public Task<GetEmpresaDetallesPostuladoResponse> GetDetallesPostulado(GetEmpresaDetallesPostuladoRequest request);
    }
}
