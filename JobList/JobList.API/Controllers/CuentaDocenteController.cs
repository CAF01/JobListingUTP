namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("CuentaDocente")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaDocenteController : ControllerBase
    {
        private readonly IMediator mediator;

        public CuentaDocenteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add-docente")]
        public async Task<IActionResult> PostDocente(InsertDocenteRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPost("login-docente")]
        public async Task<IActionResult> PostLoginDocente(LoginDocenteRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpGet("list-historial-ofertas-docente")]
        public async Task<IActionResult> GetHistorialOfertas(int idUsuarioDocente)
        {
            var result = await this.mediator.Send(new ReadHistorialOfertasDocenteRequest()
            {
                idUsuarioDocente = idUsuarioDocente
            });
            return HelperResult.Result(result);
        }

        [HttpGet("list-ofertas-revision-docente")]
        public async Task<IActionResult> GetOfertasRevision(int idUsuarioDocente)
        {
            var result = await this.mediator.Send(new ReadOfertasRevisionDocenteRequest()
            {
                idUsuarioDocente = idUsuarioDocente
            });
            return HelperResult.Result(result);
        }

        [HttpGet("list-ofertas-activas-docente")]
        public async Task<IActionResult> GetOfertasActivas(int idUsuarioDocente)
        {
            var result = await this.mediator.Send(new ReadOfertasActivasDocenteRequest()
            {
                idUsuarioDocente = idUsuarioDocente
            });
            return HelperResult.Result(result);
        }

        [HttpGet("list-postulaciones-oferta-docente")]
        public async Task<IActionResult> GetPostulacionesOferta(int idOferta)
        {
            var result = await this.mediator.Send(new ReadPostulacionesOfertaRequest()
            {
                idOferta = idOferta
            });
            return HelperResult.Result(result);
        }

        [HttpGet("detalles-oferta-docente")]
        public async Task<IActionResult> GetDetallesOferta(int idOferta)
        {
            var result = await this.mediator.Send(new ReadDetallesOfertaRequest()
            {
                idOferta = idOferta
            });
            return HelperResult.Result(result);
        }

        [HttpDelete("delete-oferta-docente")]
        public async Task<IActionResult> DeleteOfertaActiva(int idOferta)
        {
            var result = await this.mediator.Send(new DeleteOfertaActivaDocenteRequest()
            {
                idOferta = idOferta
            });
            return HelperResult.Result(result);
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDocenteRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
    }
}
