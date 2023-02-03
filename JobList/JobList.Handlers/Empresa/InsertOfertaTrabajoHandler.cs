namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class InsertOfertaTrabajoHandler : IRequestHandler<InsertOfertaTrabajoRequest, InsertOfertaTrabajoResponse>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public InsertOfertaTrabajoHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }

        public async Task<InsertOfertaTrabajoResponse> Handle(InsertOfertaTrabajoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEmpresaService.insertOfertaTrabajo(request);
            if(result.idOferta>0)
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
                idOferta = result.idOferta,
                mensaje = ValidationResources.failInsert,
                success = false
            };
        }
    }
}
