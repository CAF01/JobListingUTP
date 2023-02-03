namespace JobList.Services.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;

    public interface ICuentaAdministradorService
    {
        public Task<int> addAdministrador(InsertAdminRequest request);
        public Task<AdminInfo> loginAdministradorConToken(LoginAdminRequest userLogin);
        public Task<IEnumerable<ReadOfertasNuevasAdministradorResponse>> readOfertasNuevasAdministrador();
        public Task<IEnumerable<ReadOfertasActivasAdministradorResponse>> readOfertasActivasAdministrador();
        public Task<IEnumerable<ReadEmpresasAfiliadasResponse>> readEmpresasAfiliadas();
        public Task<IEnumerable<ReadDetallesEmpresaResponse>> readDetallesEmpresa(ReadDetallesEmpresaRequest request);
        public Task<IEnumerable<ReadOfertasPublicadasEmpresaResponse>> readOfertasPublicadasEmpresa(ReadOfertasPublicadasEmpresaRequest request);
        public Task<IEnumerable<ReadSeguimientosPostulacionEgresadosResponse>> readSeguimientosPostulacionEgresados();
    }
}
