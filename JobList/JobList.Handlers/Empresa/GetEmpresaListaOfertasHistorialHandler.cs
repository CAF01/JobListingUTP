namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class GetEmpresaListaOfertasHistorialHandler : IRequestHandler<GetEmpresaOfertasHistorialRequest, PaginationListResponse<GetEmpresaOfertasHistorialResponse>>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public GetEmpresaListaOfertasHistorialHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }
        public async Task<PaginationListResponse<GetEmpresaOfertasHistorialResponse>> Handle(GetEmpresaOfertasHistorialRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEmpresaService.getOfertasHistorialEmpresa(request);
        }
    }
}
