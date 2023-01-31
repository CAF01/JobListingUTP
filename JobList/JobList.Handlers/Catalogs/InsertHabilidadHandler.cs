namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class InsertHabilidadHandler : IRequestHandler<InsertHabilidadRequest, InsertHabilidadResponse>
    {
        private readonly IHabilidadesService habilidadesService;

        public InsertHabilidadHandler(IHabilidadesService habilidadesService)
        {
            this.habilidadesService = habilidadesService;
        }
        public async Task<InsertHabilidadResponse> Handle(InsertHabilidadRequest request, CancellationToken cancellationToken)
        {
            var result = await this.habilidadesService.addHabilidad(request);
            if(result>0)
            {
                return new InsertHabilidadResponse()
                {
                    idHabilidad= result,
                    descripcion=request.descripcion,
                    mensaje=ValidationResources.successInsert
                };
            }
            return new InsertHabilidadResponse()
            {
                idHabilidad = result,
                descripcion = request.descripcion,
                mensaje = ValidationResources.failInsert
            };
        }
    }
}
