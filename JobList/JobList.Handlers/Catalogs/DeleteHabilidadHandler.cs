using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Catalogs
{
    public class DeleteHabilidadHandler : IRequestHandler<DeleteHabilidadRequest, DeleteHabilidadResponse>
    {
        private readonly IHabilidadesService habilidadesService;

        public DeleteHabilidadHandler(IHabilidadesService habilidadesService)
        {
            this.habilidadesService = habilidadesService;
        }
        public async Task<DeleteHabilidadResponse> Handle(DeleteHabilidadRequest request, CancellationToken cancellationToken)
        {
            var result = await this.habilidadesService.deleteHabilidad(request);

            if(result)
            {
                return new DeleteHabilidadResponse() { 
                    idHabilidad=request.idHabilidad,
                    mensaje=ValidationResources.successDelete,
                    success=result
                };
            }
            return new DeleteHabilidadResponse()
            {
                idHabilidad = request.idHabilidad,
                mensaje = ValidationResources.failDelete,
                success = result
            };
        }
    }
}
