using JobList.Entities.Helpers;
using JobList.Entities.Models;
using JobList.Entities.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace JobList.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    [SwaggerTag("Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaAdministradorController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ConfigurationPaging options;

        public CuentaAdministradorController(IMediator mediator, IOptions<ConfigurationPaging> options)
        {
            this.mediator = mediator;
            this.options = options.Value;
        }

        [HttpPost("add-admin")]
        public async Task<IActionResult> PostAdministrador(InsertAdminRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [AllowAnonymous]
        [HttpPost("login-admin")]
        public async Task<IActionResult> PostLoginAdministrador(LoginAdminRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpGet("list-ofertas-nuevas")]
        public async Task<IActionResult> GetNuevasOfertasAdministrador()
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new ReadOfertasNuevasAdministradorRequest()
            {
                Skip = skip,
                Take = take
            });
            return HelperResult.Result(result);
        }

        [HttpGet("list-ofertas-activas")]
        public async Task<IActionResult> GetOfertasActivasAdministrador()
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new ReadOfertasActivasAdministradorRequest()
            {
                Skip = skip,
                Take = take
            });
            return HelperResult.Result(result);
        }

        [HttpGet("list-empresas-afiliadas")]
        public async Task<IActionResult> GetEmpresasAfiliadas()
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new ReadEmpresasAfiliadasRequest()
            {
                Skip = skip,
                Take = take
            });
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
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new ReadOfertasPublicadasEmpresaRequest()
            {
                idUsuarioEmpresa = idUsuarioEmpresa,
                Skip = skip,
                Take = take
            });
            return HelperResult.Result(result);
        }

        [HttpGet("list-seguimientos-postulacion-egresados")]
        public async Task<IActionResult> GetSeguimientosPostulacionEgresados()
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new ReadSeguimientosPostulacionEgresadosRequest() 
            { 
                Skip = skip, 
                Take = take 
            });
            return HelperResult.Result(result);
        }

        [HttpPut("validar-oferta")]
        public async Task<IActionResult> PutEstadoOferta(UpdateAdministradorOfertaValidacionRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        
    }
}
