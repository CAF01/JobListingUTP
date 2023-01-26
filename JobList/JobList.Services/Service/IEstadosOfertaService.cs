namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    public interface IEstadosOfertaService
    {
        public Task<bool> addEstadoOferta(insertEstadoOfertaRequest request);
    }
}
