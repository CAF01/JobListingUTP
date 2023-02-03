namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    public class ReadGenerosHandler : IRequestHandler<ReadGenerosRequest, List<ReadGenerosResponse>>
    {
        private readonly IGenerosService generosService;

        public ReadGenerosHandler(IGenerosService generosService)
        {
            this.generosService = generosService;
        }

        public async Task<List<ReadGenerosResponse>> Handle(ReadGenerosRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadGenerosResponse> listGeneros = await this.generosService.readGeneros();
            return listGeneros.ToList();
        }
    }
}
