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
    }
}
