using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Egresado
{
    public class InsertHabilidadEgresadoHandler : IRequestHandler<InsertHabilidadEgresadoRequest, InsertHabilidadEgresadoResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public InsertHabilidadEgresadoHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<InsertHabilidadEgresadoResponse> Handle(InsertHabilidadEgresadoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEgresadoService.addHabilidadEgresado(request);
            if(result>0)
            {
                return new InsertHabilidadEgresadoResponse()
                {
                    mensaje = ValidationResources.successInsert,
                    success = true
                };
            }
            return new InsertHabilidadEgresadoResponse()
            {
                mensaje = ValidationResources.failInsert,
                success = false
            };
        }
    }
}
