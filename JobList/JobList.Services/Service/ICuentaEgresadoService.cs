using JobList.Entities.Models;
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
        public Task<PaginationListResponse<ReadOfertasActivasFiltroEgresadoResponse>> readOfertasActivasFiltroEgresado(ReadOfertasActivasFiltroEgresadoRequest request);
        public Task<PaginationListResponse<GetEgresadoPostulacionesResponse>> getPostulacionesEgresado(GetEgresadoPostulacionesRequest request);
        public Task<PaginationListResponse<GetEgresadoListaOfertasActivasResponse>> getOfertasActivasEgresado(GetEgresadoListaOfertasActivasRequest request);
        public Task<PaginationListResponse<GetEmpresaOfertasRevisionResponse>> getOfertasRevisionEgresado(GetEgresadoOfertasRevisionRequest request);
        public Task<PaginationListResponse<GetEgresadoOfertasHistorialResponse>> getOfertasHistorialEgresado(GetEgresadoOfertasHistorialRequest request);
        public Task<GetEgresadoBasicInfoResponse> GetBasicInfo(GetEgresadoBasicInfoRequest request);
        public Task<updateEgresadoFotoResponse> updateFoto(updateEgresadoFotoRequest request);
        public Task<string> getUrlById(int idUsuario);

        public Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoExternaEgresadoRequest request);
    }
}
