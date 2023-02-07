using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Handlers.Empresa
{
    public class LoginEmpresaHandler : IRequestHandler<LoginEmpresaRequest, LoginEmpresaResponse>
    {
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public LoginEmpresaHandler(ICuentaEmpresaService cuentaEmpresaService)
        {
            this.cuentaEmpresaService = cuentaEmpresaService;
        }

        public async Task<LoginEmpresaResponse> Handle(LoginEmpresaRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEmpresaService.loginEmpresaConToken(request);
            if (result == null)
            {
                return new LoginEmpresaResponse()
                {
                    idUsuario = -1,
                    success = false,
                    token = string.Empty,
                    usuario = request.usuario
                };
            }
            return new LoginEmpresaResponse()
            {
                idUsuario = result.idUsuario,
                success = true,
                token = result.token,
                usuario = request.usuario,
                nombreEmpresa = result.nombreEmpresa
            };
        }
    }
}
