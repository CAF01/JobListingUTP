namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IMediator mediator;

        public GenerosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetGeneros()
        {
            var result = await this.mediator.Send(new ReadGenerosRequest());
            return HelperResult.Result(result);
        }
    }
}
