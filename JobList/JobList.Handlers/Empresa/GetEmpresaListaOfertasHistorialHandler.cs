namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class GetEmpresaListaOfertasHistorialHandler : IRequestHandler<GetEmpresaOfertasHistorialRequest, IEnumerable<GetEmpresaOfertasHistorialResponse>>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public GetEmpresaListaOfertasHistorialHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }
        public async Task<IEnumerable<GetEmpresaOfertasHistorialResponse>> Handle(GetEmpresaOfertasHistorialRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEmpresaService.getOfertasHistorialEmpresa(request);
        }
    }
}
