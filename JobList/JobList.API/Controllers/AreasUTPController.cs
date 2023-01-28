using JobList.Entities.Helpers;
using JobList.Entities.Requests;
using JobList.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobList.API.Controllers
{
    [SwaggerTag("AreasUTP")]
    [Route("api/[controller]")]
    [ApiController]
    public class AreasUTPController : ControllerBase
    {
        private readonly IAreasUTPService areasUTPService;

        public AreasUTPController(IAreasUTPService areasUTP)
        {
            this.areasUTPService = areasUTP;
        }

        [HttpPost("new-division")]
        public async Task<IActionResult> PostDivision(insertDivisionRequest request)
        {
            var result = await this.areasUTPService.addDivision(request);
            return HelperResult.Result(result);
        }

        [HttpPost("new-area")]
        public async Task<IActionResult> PostArea(insertAreaRequest request)
        {
            var result = await this.areasUTPService.addArea(request);
            return HelperResult.Result(result);
        }
    }
}
