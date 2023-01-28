namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("CuentaDocente")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaDocenteController : ControllerBase
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public CuentaDocenteController(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        [HttpPost]
        public async Task<IActionResult> PostDocente(insertDocenteRequest request)
        {
            var result = await this.cuentaDocenteService.addDocente(request);
            return HelperResult.Result(result);
        }
    }
}
