namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    public interface IEstadosPostulacionService
    {
        public Task<int> addEstadoPostulacion(InsertEstadoPostulacionRequest request);
    }
}
