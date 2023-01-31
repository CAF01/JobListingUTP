namespace JobList.Handlers.Administrador
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class LoginAdminHandler : IRequestHandler<LoginAdminRequest, LoginAdminResponse>
    {
        private readonly ICuentaAdministradorService cuentaAdministradorService;

        public LoginAdminHandler(ICuentaAdministradorService cuentaAdministradorService)
        {
            this.cuentaAdministradorService = cuentaAdministradorService;
        }
        public async Task<LoginAdminResponse> Handle(LoginAdminRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaAdministradorService.loginAdministradorConToken(request);
            if (result == null)
            {
                return new LoginAdminResponse()
                {
                    idUsuario=0,
                    success=false,
                    token=string.Empty,
                    usuario=request.usuario
                };
            }
            return new LoginAdminResponse()
            {
                idUsuario = result.idUsuario,
                success = true,
                token = result.token,
                usuario = request.usuario,
                nombre= result.nombre
            };
        }
    }
}
