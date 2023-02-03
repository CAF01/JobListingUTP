namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetEgresadoListaOfertasActivasHandler : IRequestHandler<GetEgresadoListaOfertasActivasRequest, IEnumerable<GetEgresadoListaOfertasActivasResponse>>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public GetEgresadoListaOfertasActivasHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }

        public async Task<IEnumerable<GetEgresadoListaOfertasActivasResponse>> Handle(GetEgresadoListaOfertasActivasRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEgresadoService.getOfertasActivasEgresado(request);
        }
    }
}
