using JobList.Entities.Helpers;
using JobList.Entities.Requests;
using JobList.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobList.API.Controllers
{
    [SwaggerTag("Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaAdministradorController : ControllerBase
    {
        private readonly ICuentaAdministradorService cuentaAdministrador;

        public CuentaAdministradorController(ICuentaAdministradorService cuentaAdministrador)
        {
            this.cuentaAdministrador = cuentaAdministrador;
        }

        [HttpPost]
        public async Task<IActionResult> PostAdministrador(insertAdminRequest request)
        {
            var result = await this.cuentaAdministrador.addAdministrador(request);
            return HelperResult.Result(result);
        }
    }
}
