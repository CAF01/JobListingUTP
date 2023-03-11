namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Swashbuckle.AspNetCore.Annotations;
    [Authorize(Roles = "RolEgresado")]
    [SwaggerTag("CuentaEgresado")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaEgresadoController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ConfigurationPaging options;

        public CuentaEgresadoController(IMediator mediator, IOptions<ConfigurationPaging> options)
        {
            this.mediator = mediator;
            this.options = options.Value;
        }

        [HttpPost("add-account-egresado")]
        public async Task<IActionResult> PostEgresado(InsertEgresadoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpPost("add-habilidad-egresado")]
        public async Task<IActionResult> PostHabilidad(InsertHabilidadEgresadoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpPost("add-conocimiento-egresado")]
        public async Task<IActionResult> PostConocimiento(InsertConocimientoEgresadoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [AllowAnonymous]
        [HttpPost("login-account-egresado")]
        public async Task<IActionResult> LoginEgresado(LoginEgresadoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordEgresadoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpPut("update-datos-personales")]
        public async Task<IActionResult> UpdatePassword(UpdateEgresadoDatosPersonalesRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpPost("add-experiencia-laboral-egresado")]
        public async Task<IActionResult> PostExperienciaLaboral(InsertEgresadoExpLaboralRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpPut("update-perfil")]
        public async Task<IActionResult> UpdatePerfil(UpdatePerfilEgresadoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpGet("get-datos-personales")]
        public async Task<IActionResult> GetDatosPersonales(int idUsuario)
        {
            var result = await this.mediator.Send(new GetEgresadoInfoPersonalRequest() { idUsuario=idUsuario});
            return HelperResult.Result(result);
        }

        [HttpGet("get-informacion-basica")]
        public async Task<IActionResult> GetInformacionBasica(int idUsuario)
        {
            var result = await this.mediator.Send(new GetEgresadoBasicInfoRequest() { idUsuario = idUsuario });
            return HelperResult.Result(result);
        }
        
        [HttpGet("get-info-completo")]
        public async Task<IActionResult> GetPerfilCompleto(int idUsuario)
        {
            var result = await this.mediator.Send(new GetEgresadoInfoPerfilRequest() { idUsuario=idUsuario});
            return HelperResult.Result(result);
        }
        [HttpGet("get-postulaciones-egresado")]
        public async Task<IActionResult> GetPostulacionEgresado(int idUsuario)
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new GetEgresadoPostulacionesRequest() {
                idUsuario = idUsuario,
                Skip = skip,
                Take = take
            });
            return HelperResult.Result(result);
        }
        
        [HttpGet("get-ofertas-activas")]
        public async Task<IActionResult> GetListaOfertasActivas(int idUsuario)
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new GetEgresadoListaOfertasActivasRequest() 
            {
                idUsuario = idUsuario,
                Skip = skip,
                Take = take
            });
            return HelperResult.Result(result);
        }

        [HttpGet("get-ofertas-activas-filtro")]
        public async Task<IActionResult> GetOfertasActivasFiltroEgresado(int idUsuario)
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new ReadOfertasActivasFiltroEgresadoRequest()
            {
                idUsuarioEgresado = idUsuario,
                Skip = skip,
                Take = take
            });
            return HelperResult.Result(result);
        }

        [HttpGet("get-detalles-oferta")]
        public async Task<IActionResult> GetDetallesOferta(int idOferta)
        {
            var result = await this.mediator.Send(new GetOfertasTrabajoDetalleRequest() { idOferta = idOferta });
            return HelperResult.Result(result);
        }

        [HttpGet("obtener-ofertas-revision")]
        public async Task<IActionResult> GetOfertasRevision(int idUsuario)
        {
            var skip = Convert.ToInt16(HttpContext.Request.Query["skip"]);
            var take = string.IsNullOrEmpty(HttpContext.Request.Query["take"]) ? options.PageSize : Convert.ToInt16(HttpContext.Request.Query["take"]);
            var result = await this.mediator.Send(new GetEgresadoOfertasRevisionRequest()
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
            var result = await this.mediator.Send(new GetEgresadoOfertasHistorialRequest()
            {
                idUsuario = idUsuario,
                Skip = skip,
                Take = take
            });
            return HelperResult.Result(result);
        }
        
        //[HttpPost("crear-oferta")]
        //public async Task<IActionResult> PostOfertaEmpresa(InsertOfertaTrabajoExternaRequest request)
        //{
        //    var result = await this.mediator.Send(request);
        //    return HelperResult.Result(result);
        //}

        [HttpPut("borrar-oferta-activa")]
        public async Task<IActionResult> PutDeleteOfertaActiva(DeleteOfertaTrabajoActivaRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPut("actualizar-estado-postulacion")]
        public async Task<IActionResult> PutEstadoPostulacion(UpdateEstadoPostulacionRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPost("crear-oferta")]
        public async Task<IActionResult> PostOfertaEgresado(InsertOfertaTrabajoExternaEgresadoRequest request)
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
            PostEgresadoImageRequest request = new PostEgresadoImageRequest();
            request.idUsuario = idUsuario;
            request.file= formFile;
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPost("upload-detalle-image")]
        public async Task<IActionResult> PostDetalleImage(IFormFile formFile)
        {
            PostDetalleContactoImageRequest request = new PostDetalleContactoImageRequest();
            request.file = formFile;
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        
    }
}
