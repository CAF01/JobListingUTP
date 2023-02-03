namespace JobList.Services.Service
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;

    public interface ICuentaAdministradorService
    {
        public Task<int> addAdministrador(InsertAdminRequest request);
        public Task<AdminInfo> loginAdministradorConToken(LoginAdminRequest userLogin);
        public Task<IEnumerable<OfertaNuevaAdministrador>> readOfertasNuevasAdministrador();
        public Task<IEnumerable<OfertaActivaAdministrador>> readOfertasActivasAdministrador();
        public Task<IEnumerable<EmpresaAfiliada>> readEmpresasAfiliadas();
        public Task<IEnumerable<DetallesEmpresa>> readDetallesEmpresa(ReadDetallesEmpresaRequest request);
        public Task<IEnumerable<OfertaPublicadaEmpresa>> readOfertasPublicadasEmpresa(ReadOfertasPublicadasEmpresaRequest request);
        public Task<IEnumerable<SeguimientoPostulacionEgresado>> readSeguimientosPostulacionEgresados();
    }
}
