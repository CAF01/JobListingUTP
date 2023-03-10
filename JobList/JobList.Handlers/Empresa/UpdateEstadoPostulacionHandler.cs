namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateEstadoPostulacionHandler : IRequestHandler<UpdateEstadoPostulacionRequest, UpdateEstadoPostulacionResponse>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public UpdateEstadoPostulacionHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }

        public async Task<UpdateEstadoPostulacionResponse> Handle(UpdateEstadoPostulacionRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEmpresaService.updateEstadoPostulacion(request);
            if (result)
            {
                return new UpdateEstadoPostulacionResponse()
                {
                    mensaje = ValidationResources.successUpdate,
                    success = result
                };
            }
            return new UpdateEstadoPostulacionResponse()
            {
                mensaje = ValidationResources.failUpdate,
                success = result
            };
        }
    }
}
