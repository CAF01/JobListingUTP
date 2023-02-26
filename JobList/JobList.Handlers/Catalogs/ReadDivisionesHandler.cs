namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    public class ReadDivisionesHandler : IRequestHandler<ReadDivisionesRequest, IEnumerable<ReadDivisionesResponse>>
    {
        private readonly IAreasUTPService areasUTPService;

        public ReadDivisionesHandler(IAreasUTPService areasUTPService)
        {
            this.areasUTPService = areasUTPService;
        }

        // Tarea para obtener lista de divisiones
        public async Task<IEnumerable<ReadDivisionesResponse>> Handle(ReadDivisionesRequest request, CancellationToken cancellationToken)
        {
            return await this.areasUTPService.readDivisiones();
        }
    }
}
