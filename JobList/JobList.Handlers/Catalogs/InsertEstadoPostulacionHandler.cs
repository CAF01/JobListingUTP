namespace JobList.Handlers.Catalogs
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;

    public class InsertEstadoPostulacionHandler : IRequestHandler<InsertEstadoPostulacionRequest, InsertEstadoPostulacionResponse>
    {
        private readonly IEstadosPostulacionService estadosPostulacionService;

        public InsertEstadoPostulacionHandler(IEstadosPostulacionService estadosPostulacionService)
        {
            this.estadosPostulacionService = estadosPostulacionService;
        }
        public async Task<InsertEstadoPostulacionResponse> Handle(InsertEstadoPostulacionRequest request, CancellationToken cancellationToken)
        {
            var result = await this.estadosPostulacionService.addEstadoPostulacion(request);
            if(result>0)
            {
                return new InsertEstadoPostulacionResponse()
                {
                    idEstadoPostulacion = result,
                    descripcion = request.descripcion,
                    mensaje = ValidationResources.successInsert
                };
            }
            return new InsertEstadoPostulacionResponse()
            {
                idEstadoPostulacion = result,
                descripcion = request.descripcion,
                mensaje = ValidationResources.failInsert
            };
        }
    }
}
