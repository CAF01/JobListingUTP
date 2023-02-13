namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class DeleteOfertaActivaHandler : IRequestHandler<DeleteOfertaTrabajoActivaRequest, DeleteOfertaTrabajoActivaResponse>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public DeleteOfertaActivaHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }
        public async Task<DeleteOfertaTrabajoActivaResponse> Handle(DeleteOfertaTrabajoActivaRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEmpresaService.SetStatusOfertaActivaBorrar(request);
            if(result)
            {
                return new DeleteOfertaTrabajoActivaResponse()
                {
                    mensaje = ValidationResources.successDelete,
                    success = result
                };
            }
            return new DeleteOfertaTrabajoActivaResponse()
            {
                mensaje = ValidationResources.failDelete,
                success = false
            };
        }
    }
}
