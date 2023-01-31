using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Catalogs
{
    public class UpdateHabilidadHandler : IRequestHandler<UpdateHabilidadRequest, UpdateHabilidadResponse>
    {
        private readonly IHabilidadesService habilidadesService;

        public UpdateHabilidadHandler(IHabilidadesService habilidadesService)
        {
            this.habilidadesService = habilidadesService;
        }
        public async Task<UpdateHabilidadResponse> Handle(UpdateHabilidadRequest request, CancellationToken cancellationToken)
        {
            var result = await this.habilidadesService.updateHabilidad(request);
            if(result)
            {
                return new UpdateHabilidadResponse()
                {
                    idHabilidad = request.idHabilidad,
                    mensaje = ValidationResources.successUpdate,
                    success = true
                };
            }
            return new UpdateHabilidadResponse()
            {
                idHabilidad = request.idHabilidad,
                mensaje = ValidationResources.failUpdate,
                success = false
            };
        }
    }
}
