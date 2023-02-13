namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class GetOfertaTrabajoDetalleHandler : IRequestHandler<GetOfertasTrabajoDetalleRequest, GetOfertasTrabajoDetalleResponse>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public GetOfertaTrabajoDetalleHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }
        public async Task<GetOfertasTrabajoDetalleResponse> Handle(GetOfertasTrabajoDetalleRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEmpresaService.GetDetallesOferta(request);
        }
    }
}
