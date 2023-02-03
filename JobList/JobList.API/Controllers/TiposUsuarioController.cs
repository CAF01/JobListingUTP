using JobList.Entities.Helpers;
using JobList.Entities.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public TiposUsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTiposUsuario()
        {
            var result = await this.mediator.Send(new ReadTiposUsuarioRequest());
            return HelperResult.Result(result);
        }
    }
}
