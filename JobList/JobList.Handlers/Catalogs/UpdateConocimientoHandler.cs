namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class UpdateConocimientoHandler : IRequestHandler<UpdateConocimientoRequest, UpdateConocimientoResponse>
    {
        private readonly IConocimientosService conocimientosService;

        public UpdateConocimientoHandler(IConocimientosService conocimientosService)
        {
            this.conocimientosService = conocimientosService;
        }
        public async Task<UpdateConocimientoResponse> Handle(UpdateConocimientoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.conocimientosService.updateConocimiento(request);
            if(result)
            {
                return new UpdateConocimientoResponse()
                {
                    descripcion = request.nuevaDescripcion,
                    mensaje = ValidationResources.successUpdate,
                    success = result
                };
            }
            return new UpdateConocimientoResponse()
            {
                descripcion = request.nuevaDescripcion,
                mensaje = ValidationResources.failUpdate,
                success = result
            };
        }
    }
}
