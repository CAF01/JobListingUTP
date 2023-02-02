using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Handlers.Docente
{
    public class LoginDocenteHandler : IRequestHandler<LoginDocenteRequest, LoginDocenteResponse>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public LoginDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<LoginDocenteResponse> Handle(LoginDocenteRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaDocenteService.loginDocenteConToken(request);
            if (result == null)
            {
                return new LoginDocenteResponse()
                {
                    idUsuario = 0,
                    success = false,
                    token = string.Empty,
                    usuario = request.usuario
                };
            }
            return new LoginDocenteResponse()
            {
                idUsuario = result.idUsuario,
                success = true,
                token = result.token,
                usuario = request.usuario,
                nombre = result.nombre
            };
        }
    }
}
