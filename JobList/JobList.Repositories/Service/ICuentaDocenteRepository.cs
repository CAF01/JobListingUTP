using JobList.Entities.Requests;
using JobList.Entities.Responses;

namespace JobList.Repositories.Service
{
    public interface ICuentaDocenteRepository
    {
        public Task<int> addDocente(InsertDocenteRequest request);
        public Task<LoginDocenteResponse> findDocente(LoginDocenteRequest userLogin);
        public Task<IEnumerable<ReadHistorialOfertasDocenteResponse>> readHistorialOfertasDocente(ReadHistorialOfertasDocenteRequest request);
        public Task<IEnumerable<ReadOfertasRevisionDocenteResponse>> readOfertasRevisionDocente(ReadOfertasRevisionDocenteRequest request);
        public Task<IEnumerable<ReadOfertasActivasDocenteResponse>> readOfertasActivasDocente(ReadOfertasActivasDocenteRequest request);
        public Task<UpdatePasswordDocenteResponse> updatePassword(UpdatePasswordDocenteRequest request);
        public Task<bool> updateUltimoAccesoSistema(int idUsuario);
        public Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoExternaRequest request);
    }
}
