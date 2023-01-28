namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("Habilidades")]
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadesController : ControllerBase
    {
        private readonly IHabilidadesService habilidadesService;

        public HabilidadesController(IHabilidadesService habilidades)
        {
            this.habilidadesService = habilidades;
        }

        [HttpPost]
        public async Task<IActionResult> PostHabilidad(insertHabilidadRequest request)
        {
            var result = await this.habilidadesService.addHabilidad(request);
            return HelperResult.Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutHabilidad(updateHabilidadRequest request)
        {
            var result = await this.habilidadesService.updateHabilidad(request);
            return HelperResult.Result(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHabilidad(deleteHabilidadRequest request)
        {
            var result = await this.habilidadesService.deleteHabilidad(request);
            return HelperResult.Result(result);
        }
    }
}
