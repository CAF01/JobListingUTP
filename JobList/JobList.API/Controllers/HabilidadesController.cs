namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    [Authorize(Roles = "Administrador")]
    [SwaggerTag("Habilidades")]
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        private readonly IMediator mediator;

        public HabilidadesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostHabilidad(InsertHabilidadRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutHabilidad(UpdateHabilidadRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHabilidad(DeleteHabilidadRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [AllowAnonymous]
        [HttpGet("list-habilidades")]
        public async Task<IActionResult> GetHabilidades()
        {
            var result = await this.mediator.Send(new ReadHabilidadesRequest());
            return HelperResult.Result(result);
        }
    }
}
