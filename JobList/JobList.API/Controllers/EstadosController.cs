namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("Estados")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadosOfertaService estadosOfertaService;
        private readonly IEstadosPostulacionService estadosPostulacionService;

        public EstadosController(IEstadosOfertaService estadosOferta,IEstadosPostulacionService estadosPostulacion)
        {
            this.estadosOfertaService = estadosOferta;
            this.estadosPostulacionService = estadosPostulacion;
        }

        [HttpPost("new-estado-oferta")]
        public async Task<IActionResult> PostEstadoOferta(insertEstadoOfertaRequest request)
        {
            var result = await this.estadosOfertaService.addEstadoOferta(request);
            return HelperResult.Result(result);
        }

        [HttpPost("new-estado-postulacion")]
        public async Task<IActionResult> PostEstadoPostulacion(insertEstadoPostulacionRequest request)
        {
            var result = await this.estadosPostulacionService.addEstadoPostulacion(request);
            return HelperResult.Result(result);
        }

    }
}
