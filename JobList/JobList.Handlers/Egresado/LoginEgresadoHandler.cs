using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Egresado
{
    public class LoginEgresadoHandler : IRequestHandler<LoginEgresadoRequest, LoginEgresadoResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public LoginEgresadoHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<LoginEgresadoResponse> Handle(LoginEgresadoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEgresadoService.findEgresado(request);
            if (result == null)
            {
                return new LoginEgresadoResponse()
                {
                    idUsuario = 0,
                    nombre = string.Empty,
                    apellido = string.Empty,
                    statusPassword = false,
                    token = string.Empty,
                    success = false,
                    usuario = request.usuario,
                    mensaje =string.Empty
                };
            }
            return new LoginEgresadoResponse()
            {
                idUsuario = result.idUsuario,
                nombre = result.nombre,
                apellido = result.apellido,
                statusPassword = result.statusPassword,
                token = result.token,
                success = true,
                camposVacios= result.camposVacios,
                usuario = request.usuario
            };
        }
    }
}
