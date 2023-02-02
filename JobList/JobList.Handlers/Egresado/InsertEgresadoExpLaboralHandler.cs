namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class InsertEgresadoExpLaboralHandler : IRequestHandler<InsertEgresadoExpLaboralRequest, InsertEgresadoExpLaboralResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public InsertEgresadoExpLaboralHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<InsertEgresadoExpLaboralResponse> Handle(InsertEgresadoExpLaboralRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEgresadoService.addExperienciaLaboral(request);
            if(result>0)
            {
                return new InsertEgresadoExpLaboralResponse()
                {
                    idExpLaboral = result,
                    success = true,
                    mensaje = ValidationResources.successInsert
                };
            }
            return new InsertEgresadoExpLaboralResponse()
            {
                idExpLaboral = result,
                success = false,
                mensaje=ValidationResources.failInsert
            };
        }
    }
}
