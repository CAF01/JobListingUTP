using JobList.Entities.Helpers;
using JobList.Entities.Models;
using JobList.Entities.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobList.API.Controllers
{
    [SwaggerTag("Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaAdministradorController : ControllerBase
    {
        private readonly IMediator mediator;

        public CuentaAdministradorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add-admin")]
        public async Task<IActionResult> PostAdministrador(InsertAdminRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPost("login-admin")]
        public async Task<IActionResult> PostLoginAdministrador(LoginAdminRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpGet("list-ofertas-nuevas")]
        public async Task<IActionResult> GetNuevasOfertasAdministrador()
        {
            var result = await this.mediator.Send(new ReadOfertasNuevasAdministradorRequest());
            return HelperResult.Result(result);
        }

        [HttpGet("list-ofertas-activas")]
        public async Task<IActionResult> GetOfertasActivasAdministrador()
        {
            var result = await this.mediator.Send(new ReadOfertasActivasAdministradorRequest());
            return HelperResult.Result(result);
        }

        [HttpGet("list-empresas-afiliadas")]
        public async Task<IActionResult> GetEmpresasAfiliadas()
        {
            var result = await this.mediator.Send(new ReadEmpresasAfiliadasRequest());
            return HelperResult.Result(result);
        }

        [HttpGet("detalles-empresa")]
        public async Task<IActionResult> GetDetallesEmpresa(int idUsuarioEmpresa)
        {
            var result = await this.mediator.Send(new ReadDetallesEmpresaRequest()
            {
                idUsuarioEmpresa = idUsuarioEmpresa
            });
            return HelperResult.Result(result);
        }

        [HttpGet("list-ofertas-publicadas-empresa")]
        public async Task<IActionResult> GetOfertasPublicadasEmpresa(int idUsuarioEmpresa)
        {
            var result = await this.mediator.Send(new ReadOfertasPublicadasEmpresaRequest()
            {
                idUsuarioEmpresa = idUsuarioEmpresa
            });
            return HelperResult.Result(result);
        }

        [HttpGet("list-seguimientos-postulacion-egresados")]
        public async Task<IActionResult> GetSeguimientosPostulacionEgresados()
        {
            var result = await this.mediator.Send(new ReadSeguimientosPostulacionEgresadosRequest());
            return HelperResult.Result(result);
        }
    }
}
