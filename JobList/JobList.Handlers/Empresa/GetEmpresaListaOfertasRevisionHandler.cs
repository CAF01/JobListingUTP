namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class GetEmpresaListaOfertasRevisionHandler : IRequestHandler<GetEmpresaOfertasRevisionRequest, PaginationListResponse<GetEmpresaOfertasRevisionResponse>>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public GetEmpresaListaOfertasRevisionHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }
        public async Task<PaginationListResponse<GetEmpresaOfertasRevisionResponse>> Handle(GetEmpresaOfertasRevisionRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEmpresaService.getOfertasRevisionEmpresa(request);
        }
    }
}
