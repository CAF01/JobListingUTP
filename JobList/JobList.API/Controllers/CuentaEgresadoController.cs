namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("CuentaEgresado")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaEgresadoController : ControllerBase
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public CuentaEgresadoController(ICuentaEgresadoService cuentaEgresado)
        {
            this.cuentaEgresadoService = cuentaEgresado;
        }

        [HttpPost("add-account-egresado")]
        public async Task<IActionResult> PostEgresado(insertEgresadoRequest request)
        {
            var result = await this.cuentaEgresadoService.addEgresado(request);
            return HelperResult.Result(result);
        }
        [HttpPost("add-habilidad-egresado")]
        public async Task<IActionResult> PostHabilidad(insertHabilidadEgresadoRequest request)
        {
            var result = await this.cuentaEgresadoService.addHabilidadEgresado(request);
            return HelperResult.Result(result);
        }
        [HttpPost("add-conocimiento-egresado")]
        public async Task<IActionResult> PostConocimiento(insertConocimientoEgresadoRequest request)
        {
            var result = await this.cuentaEgresadoService.addConocimientoEgresado(request);
            return HelperResult.Result(result);
        }
    }
}
