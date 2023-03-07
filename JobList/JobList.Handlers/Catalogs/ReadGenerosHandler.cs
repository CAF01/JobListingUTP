namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    public class ReadGenerosHandler : IRequestHandler<ReadGenerosRequest, IEnumerable<ReadGenerosResponse>>
    {
        private readonly IGenerosService generosService;

        public ReadGenerosHandler(IGenerosService generosService)
        {
            this.generosService = generosService;
        }

        public async Task<IEnumerable<ReadGenerosResponse>> Handle(ReadGenerosRequest request, CancellationToken cancellationToken)
        {
            return await this.generosService.readGeneros();
        }
    }
}
