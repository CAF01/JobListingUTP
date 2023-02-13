namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class InsertEmpresaHandler : IRequestHandler<InsertEmpresaRequest, InsertEmpresaResponse>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public InsertEmpresaHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }
        public async Task<InsertEmpresaResponse> Handle(InsertEmpresaRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEmpresaService.insertCuentaEmpresa(request);
            if(result!=null && result.idEmpresa>0)
            {
                result.mensaje = ValidationResources.successInsert;
                result.success = true;
                return result;
            }

            return new InsertEmpresaResponse()
            {
                idEmpresa = -1,
                mensaje = ValidationResources.failInsert,
                success = false
            };
        }
    }
}
