namespace JobList.Repositories.Service
{
    using JobList.Entities.Requests;
    public interface IEstadosOfertaRepository
    {
        public Task<int> addEstadoOferta(InsertEstadoOfertaRequest request);
    }
}
