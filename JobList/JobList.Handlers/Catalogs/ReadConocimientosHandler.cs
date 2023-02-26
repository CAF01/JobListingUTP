namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class ReadConocimientosHandler : IRequestHandler<ReadConocimientosRequest, IEnumerable<ReadConocimientosResponse>>
    {
        private readonly IConocimientosService conocimientosService;

        public ReadConocimientosHandler(IConocimientosService conocimientosService)
        {
            this.conocimientosService = conocimientosService;
        }

        // Obtener lista de conocimientos
        public async Task<IEnumerable<ReadConocimientosResponse>> Handle(ReadConocimientosRequest request, CancellationToken cancellationToken)
        {
            return await this.conocimientosService.readConocimientos();
        }
    }
}
