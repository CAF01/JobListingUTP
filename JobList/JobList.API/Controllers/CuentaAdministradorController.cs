using JobList.Entities.Helpers;
using JobList.Entities.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobList.API.Controllers
{
    [SwaggerTag("Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaAdministradorController : ControllerBase
    {
        private readonly IMediator mediator;

        public CuentaAdministradorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add-admin")]
        public async Task<IActionResult> PostAdministrador(InsertAdminRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPost("login-admin")]
        public async Task<IActionResult> PostLoginAdministrador(LoginAdminRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
    }
}
