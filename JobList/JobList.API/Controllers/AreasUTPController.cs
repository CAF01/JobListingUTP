using JobList.Entities.Helpers;
using JobList.Entities.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobList.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    [SwaggerTag("AreasUTP")]
    [Route("api/[controller]")]
    [ApiController]
    public class AreasUTPController : ControllerBase
    {
        private readonly IMediator mediator;

        // Constructor
        public AreasUTPController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("new-area")]
        public async Task<IActionResult> PostMediatorArea(InsertAreaRequest request)
        {
            var result = await mediator.Send(request);
            return HelperResult.Result(result);
        }

        [HttpPost("new-division")]
        public async Task<IActionResult> PostMediatorDivision(InsertDivisionRequest request)
        {
            var result = await mediator.Send(request);
            return HelperResult.Result(result);
        }

        [AllowAnonymous]
        [HttpGet("list-divisiones")]
        public async Task<IActionResult> GetDivisiones()
        {
            var result = await this.mediator.Send(new ReadDivisionesRequest());
            return HelperResult.Result(result);
        }
        [AllowAnonymous]
        [HttpGet("list-areasdivision")]
        public async Task<IActionResult> GetAreasDivision(int idDivision)
        {
            var result = await this.mediator.Send(new ReadAreasDivisionRequest()
            {
                idDivision = idDivision
            });
            return HelperResult.Result(result);
        }
    }
}
