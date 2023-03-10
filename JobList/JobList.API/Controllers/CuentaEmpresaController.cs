namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    [Authorize(Roles = "Empresa")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaEmpresaController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ConfigurationPaging options;

        public CuentaEmpresaController(IMediator mediator, IOptions<ConfigurationPaging> options)
        {
            this.mediator = mediator;
            this.options = options.Value;
        }
        [AllowAnonymous]
        [HttpPost("login-empresa")]
        public async Task<IActionResult> PostLoginEmpresa(LoginEmpresaRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpPost("crear-oferta")]
        public async Task<IActionResult> PostOfertaEmpresa(InsertOfertaTrabajoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [AllowAnonymous]
        [HttpPost("crear-cuenta-empresa")]
        public async Task<IActionResult> PostEmpresa(InsertEmpresaRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpPut("actualizar-datos-empresa")]
        public async Task<IActionResult> PutEmpresa(UpdateEmpresaDatosRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpGet("obtener-ofertas-activas")]
        public async Task<IActionResult> GetOfertasActivas(int idUsuario)
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new GetEmpresaListaOfertasActivasRequest() 
            { 
                idUsuario=idUsuario,
                Skip=skip,
                Take=take
            });
            return HelperResult.Result(result);
        }
        [HttpPut("borrar-oferta-activa")]
        public async Task<IActionResult> PutDeleteOfertaActiva(DeleteOfertaTrabajoActivaRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpGet("obtener-ofertas-revision")]
        public async Task<IActionResult> GetOfertasRevision(int idUsuario)
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new GetEmpresaOfertasRevisionRequest()
            {
                idUsuario = idUsuario,
                Skip = skip,
                Take = take
            });
            return HelperResult.Result(result);
        }
        [HttpGet("obtener-ofertas-historial")]
        public async Task<IActionResult> GetOfertasHistorial(int idUsuario)
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new GetEmpresaOfertasHistorialRequest()
            {
                idUsuario = idUsuario,
                Skip = skip,
                Take = take
            });
            return HelperResult.Result(result);
        }
        [HttpGet("obtener-detalles-oferta")]
        public async Task<IActionResult> GetDetallesOferta(int idOferta)
        {
            var result = await this.mediator.Send(new GetOfertasTrabajoDetalleRequest() { idOferta = idOferta });
            return HelperResult.Result(result);
        }
    
        [HttpPut("actualizar-estado-postulacion")]
        public async Task<IActionResult> PutEstadoPostulacion(UpdateEstadoPostulacionRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> PostImage(IFormFile formFile)
        {
            var idUsuario = Convert.ToInt32(HttpContext.Request.Query["idusuario"]);
            if (idUsuario < 1)
                return null;
            PostEmpresaImageRequest request = new PostEmpresaImageRequest();
            request.idUsuario = idUsuario;
            request.file = formFile;
            var result = await this.mediator.Send(request);
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

        [HttpGet("obtener-detalles-postulado")]
        public async Task<IActionResult> GetDetallesPostulado(int idUsuario)
        {
            var result = await this.mediator.Send(new GetEmpresaDetallesPostuladoRequest() { idUsuario = idUsuario });
            return HelperResult.Result(result);
        }
    }
}
