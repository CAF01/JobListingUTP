namespace JobList.API.Controllers
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    [SwaggerTag("Conocimientos")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConocimientosController : ControllerBase
    {
        private readonly IMediator mediator;

        public ConocimientosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostConocimiento(InsertConocimientoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutConocimiento(UpdateConocimientoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteConocimiento(DeleteConocimientoRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpGet("list-conocimientos")]
        public async Task<IActionResult> GetConocimientos()
        {
            var result = await this.mediator.Send(new readConocimientosRequest());
            return HelperResult.Result(result);
        }
    }
}
