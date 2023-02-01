namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class InsertAdminHandler : IRequestHandler<InsertAdminRequest, InsertAdminResponse>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        public InsertAdminHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }
        public async Task<InsertAdminResponse> Handle(InsertAdminRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaAdministradorService.addAdministrador(request);
            if(result>0)
            {
                return new InsertAdminResponse()
                {
                    nombre = request.nombre,
                    usuario = request.usuario,
                    idUsuario = result,
                    mensaje = ValidationResources.successInsert
                };
            }
            return new InsertAdminResponse()
            {
                nombre = request.nombre,
                usuario = request.usuario,
                idUsuario = result,
                mensaje = ValidationResources.failInsert
            };
        }
    }
}
