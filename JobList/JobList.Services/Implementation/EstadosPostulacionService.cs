namespace JobList.Services.Implementation
{
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Services.Service;
    using System.Threading.Tasks;

    public class EstadosPostulacionService : IEstadosPostulacionService
    {
        private readonly IEstadosPostulacionRepository estadosPostulacionRepository;

        public EstadosPostulacionService(IEstadosPostulacionRepository estadosPostulacionRepository)
        {
            this.estadosPostulacionRepository = estadosPostulacionRepository;
        }
        public async Task<int> addEstadoPostulacion(InsertEstadoPostulacionRequest request)
        {
            return await this.estadosPostulacionRepository.addEstadoPostulacion(request);
        }
    }
}
