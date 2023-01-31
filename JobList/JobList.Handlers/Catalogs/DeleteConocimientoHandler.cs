namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;

    public class DeleteConocimientoHandler : IRequestHandler<DeleteConocimientoRequest, DeleteConocimientoResponse>
    {
        private readonly IConocimientosService conocimientosService;

        public DeleteConocimientoHandler(IConocimientosService conocimientosService)
        {
            this.conocimientosService = conocimientosService;
        }
        public async Task<DeleteConocimientoResponse> Handle(DeleteConocimientoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.conocimientosService.deleteConocimiento(request);
            if(result)
            {
                return new DeleteConocimientoResponse()
                {
                    idConocimiento = request.idConocimiento,
                    mensaje = ValidationResources.successDelete,
                    success = result
                };
            }
            return new DeleteConocimientoResponse()
            {
                idConocimiento = request.idConocimiento,
                mensaje = ValidationResources.failDelete,
                success = result
            };
        }
    }
}
