namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    [Authorize(Roles = "Administrador")]
    [SwaggerTag("Estados")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IMediator mediator;

        public EstadosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("new-estado-oferta")]
        public async Task<IActionResult> PostEstadoOferta(InsertEstadoOfertaRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPost("new-estado-postulacion")]
        public async Task<IActionResult> PostEstadoPostulacion(InsertEstadoPostulacionRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

    }
}
