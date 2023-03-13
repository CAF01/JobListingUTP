namespace JobList.Handlers.Docente
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetDocenteDetallesPostuladoHandler : IRequestHandler<GetEmpresaDetallesPostuladoRequest, GetEmpresaDetallesPostuladoResponse>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public GetDocenteDetallesPostuladoHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<GetEmpresaDetallesPostuladoResponse> Handle(GetEmpresaDetallesPostuladoRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaDocenteService.GetDetallesPostulado(request);
        }
    }
}
