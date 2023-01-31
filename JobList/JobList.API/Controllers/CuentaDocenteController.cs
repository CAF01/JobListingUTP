namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Services.Service;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;

    [SwaggerTag("CuentaDocente")]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaDocenteController : ControllerBase
    {
        private readonly IMediator mediator;

        public CuentaDocenteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostDocente(InsertDocenteRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
    }
}
