using JobList.Entities.Requests;
using JobList.Entities.Responses;

namespace JobList.Services.Service
{
    public interface ICuentaEgresadoService
    {
        public Task<int> addEgresado(InsertEgresadoRequest request);
        public Task<int> addConocimientoEgresado(InsertConocimientoEgresadoRequest request);
        public Task<int> addHabilidadEgresado(InsertHabilidadEgresadoRequest request);
        public Task<LoginEgresadoResponse> findEgresado(LoginEgresadoRequest request);
        public Task<UpdatePasswordEgresadoResponse> updatePassword(UpdatePasswordEgresadoRequest request);
        public Task<bool> updateDatosPersonales(UpdateEgresadoDatosPersonalesRequest request);
        public Task<int> addExperienciaLaboral(InsertEgresadoExpLaboralRequest request);

        public Task<UpdatePerfilEgresadoResponse> updatePerfil(UpdatePerfilEgresadoRequest request);
        public Task<GetEgresadoInfoPersonalResponse> getInfoEgresado(GetEgresadoInfoPersonalRequest request);
        public Task<GetEgresadoInfoPerfilResponse> getInfoPerfilEgresado(GetEgresadoInfoPerfilRequest request);
        public Task<IEnumerable<GetEgresadoPostulacionesResponse>> getPostulacionesEgresado(GetEgresadoPostulacionesRequest request);
        public Task<IEnumerable<GetEgresadoListaOfertasActivasResponse>> getOfertasActivasEgresado(GetEgresadoListaOfertasActivasRequest request);
        public Task<IEnumerable<GetEmpresaOfertasRevisionResponse>> getOfertasRevisionEgresado(GetEgresadoOfertasRevisionRequest request);
        public Task<IEnumerable<GetEgresadoOfertasHistorialResponse>> getOfertasHistorialEgresado(GetEgresadoOfertasHistorialRequest request);
    }
}
