using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Egresado
{
    public class UpdateEgresadoDatosPersonalesHandler : IRequestHandler<UpdateEgresadoDatosPersonalesRequest, UpdateEgresadoDatosPersonalesResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public UpdateEgresadoDatosPersonalesHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<UpdateEgresadoDatosPersonalesResponse> Handle(UpdateEgresadoDatosPersonalesRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEgresadoService.updateDatosPersonales(request);
            if(result)
            {
                return new UpdateEgresadoDatosPersonalesResponse()
                {
                    success = result,
                    mensaje = ValidationResources.successUpdate
                };
            }
            return new UpdateEgresadoDatosPersonalesResponse()
            {
                success = result,
                mensaje = ValidationResources.failUpdate
            };
        }
    }
}
