namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    public interface IEstadosPostulacionService
    {
        public Task<bool> addEstadoPostulacion(insertEstadoPostulacionRequest request);
    }
}
