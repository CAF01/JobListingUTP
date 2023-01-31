namespace JobList.Services.Implementation
{
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Services.Service;
    using System.Threading.Tasks;

    public class EstadosOfertaService : IEstadosOfertaService
    {
        private readonly IEstadosOfertaRepository estadosOfertaRepository;

        public EstadosOfertaService(IEstadosOfertaRepository estadosOfertaRepository)
        {
            this.estadosOfertaRepository = estadosOfertaRepository;
        }
        public async Task<int> addEstadoOferta(InsertEstadoOfertaRequest request)
        {
            return await this.estadosOfertaRepository.addEstadoOferta(request);
        }
    }
}
