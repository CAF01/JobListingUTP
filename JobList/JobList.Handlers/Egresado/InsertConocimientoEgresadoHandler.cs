namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class InsertConocimientoEgresadoHandler : IRequestHandler<InsertConocimientoEgresadoRequest, InsertConocimientoEgresadoResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public InsertConocimientoEgresadoHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<InsertConocimientoEgresadoResponse> Handle(InsertConocimientoEgresadoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEgresadoService.addConocimientoEgresado(request);
            if(result>0)
            {
                return new InsertConocimientoEgresadoResponse()
                {
                    mensaje = ValidationResources.successInsert,
                    success = true
                };
            }
            return new InsertConocimientoEgresadoResponse()
            {
                mensaje = ValidationResources.failInsert,
                success = false
            };
        }
    }
}
