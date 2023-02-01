using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Catalogs
{
    public class InsertConocimientoHandler : IRequestHandler<InsertConocimientoRequest, InsertConocimientoResponse>
    {
        private readonly IConocimientosService conocimientosService;

        public InsertConocimientoHandler(IConocimientosService conocimientosService)
        {
            this.conocimientosService = conocimientosService;
        }
        public async Task<InsertConocimientoResponse> Handle(InsertConocimientoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.conocimientosService.addConocimiento(request);
            if(result>0)
            {
                return new InsertConocimientoResponse()
                {
                    idConocimiento= result,
                    mensaje=ValidationResources.successInsert,
                    descripcion=request.descripcion
                };
            }
            return new InsertConocimientoResponse()
            {
                idConocimiento = result,
                mensaje = ValidationResources.failInsert,
                descripcion = request.descripcion
            };
        }
    }
}
