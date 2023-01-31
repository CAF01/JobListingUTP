namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class InsertEstadoOfertaHandler : IRequestHandler<InsertEstadoOfertaRequest, InsertEstadoOfertaResponse>
    {
        private readonly IEstadosOfertaService estadosOfertaService;

        public InsertEstadoOfertaHandler(IEstadosOfertaService estadosOfertaService)
        {
            this.estadosOfertaService = estadosOfertaService;
        }
        public async Task<InsertEstadoOfertaResponse> Handle(InsertEstadoOfertaRequest request, CancellationToken cancellationToken)
        {
            var result = await this.estadosOfertaService.addEstadoOferta(request);
            if(result>0)
            {
                return new InsertEstadoOfertaResponse()
                {
                    descripcion = request.descripcion,
                    idEstadoOferta = result,
                    mensaje = ValidationResources.successInsert
                };
            }
            return new InsertEstadoOfertaResponse()
            {
                descripcion = request.descripcion,
                idEstadoOferta = result,
                mensaje = ValidationResources.failInsert
            };
        }
    }
}
