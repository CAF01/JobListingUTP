namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    public class ReadDivisionesHandler : IRequestHandler<ReadDivisionesRequest, List<ReadDivisionesResponse>>
    {
        private readonly IAreasUTPService areasUTPService;

        public ReadDivisionesHandler(IAreasUTPService areasUTPService)
        {
            this.areasUTPService = areasUTPService;
        }

        // Tarea para obtener lista de divisiones
        public async Task<List<ReadDivisionesResponse>> Handle(ReadDivisionesRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadDivisionesResponse> listDivisiones = await this.areasUTPService.readDivisiones();
            return listDivisiones.ToList();
        }
    }
}
