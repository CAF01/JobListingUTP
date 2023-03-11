namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class GetEmpresaDetallesPostuladoHandler : IRequestHandler<GetEmpresaDetallesPostuladoRequest, GetEmpresaDetallesPostuladoResponse>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public GetEmpresaDetallesPostuladoHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }
        public async Task<GetEmpresaDetallesPostuladoResponse> Handle(GetEmpresaDetallesPostuladoRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEmpresaService.GetDetallesPostulado(request);
        }
    }
}
