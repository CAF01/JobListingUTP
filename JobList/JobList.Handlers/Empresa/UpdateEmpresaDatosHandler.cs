namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;

    public class UpdateEmpresaDatosHandler : IRequestHandler<UpdateEmpresaDatosRequest, UpdateEmpresaDatosResponse>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public UpdateEmpresaDatosHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }
        public async Task<UpdateEmpresaDatosResponse> Handle(UpdateEmpresaDatosRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEmpresaService.updateDatosEmpresa(request);
            if(result != null && result.success) {
                result.mensaje = ValidationResources.successUpdate;
                return result;
            }

            return new UpdateEmpresaDatosResponse()
            {
                mensaje = ValidationResources.failUpdate,
                success = false
            };
        }
    }
}
