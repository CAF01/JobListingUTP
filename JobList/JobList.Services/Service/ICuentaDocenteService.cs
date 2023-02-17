namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;

    public interface ICuentaDocenteService
    {
        public Task<int> addDocente(InsertDocenteRequest request);
        public Task<LoginDocenteResponse> loginDocenteConToken(LoginDocenteRequest userLogin);
        public Task<PaginationListResponse<ReadHistorialOfertasDocenteResponse>> readHistorialOfertasDocente(ReadHistorialOfertasDocenteRequest request);
        public Task<PaginationListResponse<ReadOfertasRevisionDocenteResponse>> readOfertasRevisionDocente(ReadOfertasRevisionDocenteRequest request);
        public Task<PaginationListResponse<ReadOfertasActivasDocenteResponse>> readOfertasActivasDocente(ReadOfertasActivasDocenteRequest request);    
        public Task<UpdatePasswordDocenteResponse> updatePassword(UpdatePasswordDocenteRequest request);
        public Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoExternaRequest request);
    }
}
