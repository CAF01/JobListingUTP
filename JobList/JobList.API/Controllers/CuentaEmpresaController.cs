using JobList.Entities.Helpers;
using JobList.Entities.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaEmpresaController : ControllerBase
    {
        private readonly IMediator mediator;

        public CuentaEmpresaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("login-empresa")]
        public async Task<IActionResult> PostLoginEmpresa(LoginEmpresaRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpPost("crear-oferta")]
        public async Task<IActionResult> PostOfertaEmpresa(InsertOfertaTrabajoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
    }
}
