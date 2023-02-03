namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    public class ReadHabilidadesHandler : IRequestHandler<ReadHabilidadesRequest, List<ReadHabilidadesResponse>>
    {
        private readonly IHabilidadesService habilidadesService;

        public ReadHabilidadesHandler(IHabilidadesService habilidadesService)
        {
            this.habilidadesService = habilidadesService;
        }

        // Obtener lista de habilidades
        public async Task<List<ReadHabilidadesResponse>> Handle(ReadHabilidadesRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadHabilidadesResponse> listHabilidades = await this.habilidadesService.readHabilidades();
            return listHabilidades.ToList();
        }
    }
}
