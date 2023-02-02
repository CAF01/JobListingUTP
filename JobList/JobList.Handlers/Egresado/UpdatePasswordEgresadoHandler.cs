namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class UpdatePasswordEgresadoHandler : IRequestHandler<UpdatePasswordEgresadoRequest, UpdatePasswordEgresadoResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public UpdatePasswordEgresadoHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<UpdatePasswordEgresadoResponse> Handle(UpdatePasswordEgresadoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEgresadoService.updatePassword(request);
            if(result == null)
            {
                return new UpdatePasswordEgresadoResponse()
                {
                    mensaje=ValidationResources.failUpdate,
                    success=false
                };
            }
            if(result.success)
            {
                result.mensaje = ValidationResources.successUpdate;
            }
            if (result.EqualPassword)
            {
                result.mensaje = ValidationResources.equalPassword;
            }
            return result;
        }
    }
}
