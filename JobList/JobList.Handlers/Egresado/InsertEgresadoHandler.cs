namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class InsertEgresadoHandler : IRequestHandler<InsertEgresadoRequest, InsertEgresadoResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public InsertEgresadoHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<InsertEgresadoResponse> Handle(InsertEgresadoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEgresadoService.addEgresado(request);
            if(result>0)
            {
                return new InsertEgresadoResponse()
                {
                    idUsuario = result,
                    nombre = $"{request.nombre} {request.apellido}",
                    mensaje = ValidationResources.successInsert,
                    usuario = request.usuario
                };
            }
            return new InsertEgresadoResponse()
            {
                idUsuario = result,
                nombre = string.Empty,
                mensaje = ValidationResources.failInsert,
                usuario = string.Empty
            };
        }
    }
}
