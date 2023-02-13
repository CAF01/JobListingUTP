namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class GetEmpresaListaOfertasActivasHandler : IRequestHandler<GetEmpresaListaOfertasActivasRequest, IEnumerable<GetEmpresaListaOfertasActivasResponse>>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public GetEmpresaListaOfertasActivasHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }
        public async Task<IEnumerable<GetEmpresaListaOfertasActivasResponse>> Handle(GetEmpresaListaOfertasActivasRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEmpresaService.getOfertasActivasEmpresa(request);
        }
    }
}
