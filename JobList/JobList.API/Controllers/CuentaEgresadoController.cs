namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("CuentaEgresado")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaEgresadoController : ControllerBase
    {
        private readonly IMediator mediator;

        public CuentaEgresadoController(IMediator mediator)
        {
            this.mediator = mediator;
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
        [HttpGet("get-info-completo")]
        public async Task<IActionResult> GetPerfilCompleto(int idUsuario)
        {
            var result = await this.mediator.Send(new GetEgresadoInfoPerfilRequest() { idUsuario=idUsuario});
            return HelperResult.Result(result);
        }
        [HttpGet("get-postulaciones-egresado")]
        public async Task<IActionResult> GetPostulacionEgresado(int idUsuario)
        {
            var result = await this.mediator.Send(new GetEgresadoPostulacionesRequest() { idUsuario= idUsuario });
            return HelperResult.Result(result);
        }
        
        [HttpGet("get-ofertas-activas")]
        public async Task<IActionResult> GetListaOfertasActivas(int idUsuario)
        {
            var result = await this.mediator.Send(new GetEgresadoListaOfertasActivasRequest() { idUsuario = idUsuario });
            return HelperResult.Result(result);
        }

    }
}
