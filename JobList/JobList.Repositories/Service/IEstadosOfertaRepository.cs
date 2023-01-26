namespace JobList.Repositories.Service
{
    using JobList.Entities.Requests;
    public interface IEstadosOfertaRepository
    {
        public Task<bool> addEstadoOferta(insertEstadoOfertaRequest request);
    }
}
