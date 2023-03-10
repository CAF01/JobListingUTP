namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class InsertOfertaTrabajoExternaEgresadoHandler : IRequestHandler<InsertOfertaTrabajoExternaEgresadoRequest, InsertOfertaTrabajoResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public InsertOfertaTrabajoExternaEgresadoHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }

        public async Task<InsertOfertaTrabajoResponse> Handle(InsertOfertaTrabajoExternaEgresadoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEgresadoService.insertOfertaTrabajo(request);
            if (result != null && result.idOferta > 0)
            {
                return new InsertOfertaTrabajoResponse()
                {
                    idOferta = result.idOferta,
                    mensaje = ValidationResources.successInsert,
                    success = true
                };
            }
            return new InsertOfertaTrabajoResponse()
            {
                idOferta = -1,
                mensaje = ValidationResources.failInsert,
                success = false
            };
        }
    }
}
