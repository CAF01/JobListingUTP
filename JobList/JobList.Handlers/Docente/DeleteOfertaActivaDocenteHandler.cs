using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Docente
{
    public class DeleteOfertaActivaDocenteHandler : IRequestHandler<DeleteOfertaActivaDocenteRequest, DeleteOfertaActivaDocenteResponse>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public DeleteOfertaActivaDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<DeleteOfertaActivaDocenteResponse> Handle(DeleteOfertaActivaDocenteRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaDocenteService.deleteOfertaActiva(request);
            if (result)
            {
                return new DeleteOfertaActivaDocenteResponse()
                {
                    idOferta = request.idOferta,
                    mensaje = ValidationResources.successDelete,
                    success = result
                };
            }
            return new DeleteOfertaActivaDocenteResponse()
            {
                idOferta = request.idOferta,
                mensaje = ValidationResources.failDelete,
                success = result
            };
        }
    }
}
