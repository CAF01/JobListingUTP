namespace JobList.Services.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;

    public interface ICuentaAdministradorService
    {
        public Task<int> addAdministrador(InsertAdminRequest request);
        public Task<AdminInfo> loginAdministradorConToken(LoginAdminRequest userLogin);
        public Task<PaginationListResponse<ReadOfertasNuevasAdministradorResponse>> readOfertasNuevasAdministrador();
        public Task<PaginationListResponse<ReadOfertasActivasAdministradorResponse>> readOfertasActivasAdministrador();
        public Task<PaginationListResponse<ReadEmpresasAfiliadasResponse>> readEmpresasAfiliadas();
        public Task<ReadDetallesEmpresaResponse> readDetallesEmpresa(ReadDetallesEmpresaRequest request);
        public Task<PaginationListResponse<ReadOfertasPublicadasEmpresaResponse>> readOfertasPublicadasEmpresa(ReadOfertasPublicadasEmpresaRequest request);
        public Task<PaginationListResponse<ReadSeguimientosPostulacionEgresadosResponse>> readSeguimientosPostulacionEgresados();
        public Task<bool> UpdateOfertaTrabajoValida(UpdateAdministradorOfertaValidacionRequest request);
    }
}
