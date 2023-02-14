namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;

    public class GetEgresadoListaOfertasRevisionHandler : IRequestHandler<GetEgresadoOfertasRevisionRequest, IEnumerable<GetEmpresaOfertasRevisionResponse>>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public GetEgresadoListaOfertasRevisionHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }

        public async Task<IEnumerable<GetEmpresaOfertasRevisionResponse>> Handle(GetEgresadoOfertasRevisionRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEgresadoService.getOfertasRevisionEgresado(request);
        }
    }
}
