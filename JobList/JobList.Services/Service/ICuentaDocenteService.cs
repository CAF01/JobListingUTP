namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;

    public interface ICuentaDocenteService
    {
        public Task<int> addDocente(InsertDocenteRequest request);
        public Task<LoginDocenteResponse> loginDocenteConToken(LoginDocenteRequest userLogin);
        public Task<IEnumerable<ReadHistorialOfertasDocenteResponse>> readHistorialOfertasDocente(ReadHistorialOfertasDocenteRequest request);
        public Task<IEnumerable<ReadOfertasRevisionDocenteResponse>> readOfertasRevisionDocente(ReadOfertasRevisionDocenteRequest request);
        public Task<IEnumerable<ReadOfertasActivasDocenteResponse>> readOfertasActivasDocente(ReadOfertasActivasDocenteRequest request);    
        public Task<UpdatePasswordDocenteResponse> updatePassword(UpdatePasswordDocenteRequest request);
        public Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoExternaRequest request);
    }
}
