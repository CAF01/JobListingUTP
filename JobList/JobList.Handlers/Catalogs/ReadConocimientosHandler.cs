namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class ReadConocimientosHandler : IRequestHandler<ReadConocimientosRequest, List<ReadConocimientosResponse>>
    {
        private readonly IConocimientosService conocimientosService;

        public ReadConocimientosHandler(IConocimientosService conocimientosService)
        {
            this.conocimientosService = conocimientosService;
        }

        // Obtener lista de conocimientos
        public async Task<List<ReadConocimientosResponse>> Handle(ReadConocimientosRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadConocimientosResponse> listConocimientos = await this.conocimientosService.readConocimientos();
            return listConocimientos.ToList();
        }
    }
}
