namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;

    public class UpdateAdministradorOfertaValidacionHandler : IRequestHandler<UpdateAdministradorOfertaValidacionRequest, UpdateAdministradorOfertaValidacionResponse>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        public UpdateAdministradorOfertaValidacionHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }
        public async Task<UpdateAdministradorOfertaValidacionResponse> Handle(UpdateAdministradorOfertaValidacionRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaAdministradorService.UpdateOfertaTrabajoValida(request);
            if(result)
            {
                return new UpdateAdministradorOfertaValidacionResponse()
                {
                    success = result,
                    mensaje = ValidationResources.successUpdate
                };
            }
            return new UpdateAdministradorOfertaValidacionResponse()
            {
                success = result,
                mensaje = ValidationResources.failUpdate
            };
        }
    }
}
