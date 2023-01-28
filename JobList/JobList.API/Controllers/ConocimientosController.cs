namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    [SwaggerTag("Conocimientos")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConocimientosController : ControllerBase
    {
        private readonly IConocimientosService conocimientosService;

        public ConocimientosController(IConocimientosService conocimientos)
        {
            this.conocimientosService = conocimientos;
        }

        [HttpPost]
        public async Task<IActionResult> PostConocimiento(insertConocimientoRequest request)
        {
            var result = await this.conocimientosService.addConocimiento(request);
            return HelperResult.Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutConocimiento(updateConocimientoRequest request)
        {
            var result = await this.conocimientosService.updateConocimiento(request);
            return HelperResult.Result(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteConocimiento(deleteConocimientoRequest request)
        {
            var result = await this.conocimientosService.deleteConocimiento(request);
            return HelperResult.Result(result);
        }
    }
}
