namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    public class ReadHabilidadesHandler : IRequestHandler<ReadHabilidadesRequest, IEnumerable<ReadHabilidadesResponse>>
    {
        private readonly IHabilidadesService habilidadesService;

        public ReadHabilidadesHandler(IHabilidadesService habilidadesService)
        {
            this.habilidadesService = habilidadesService;
        }

        // Obtener lista de habilidades
        public async Task<IEnumerable<ReadHabilidadesResponse>> Handle(ReadHabilidadesRequest request, CancellationToken cancellationToken)
        {
            return await this.habilidadesService.readHabilidades();
        }
    }
}
