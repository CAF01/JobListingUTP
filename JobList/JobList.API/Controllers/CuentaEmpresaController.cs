using JobList.Entities.Helpers;
using JobList.Entities.Requests;
using MediatR;
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
        [HttpPost("crear-cuenta-empresa")]
        public async Task<IActionResult> PostEmpresa(InsertEmpresaRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpPut("actualizar-datos-empresa")]
        public async Task<IActionResult> PutEmpresa(UpdateEmpresaDatosRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpGet("obtener-ofertas-activas")]
        public async Task<IActionResult> GetOfertasActivas(int idUsuario)
        {
            var result = await this.mediator.Send(new GetEmpresaListaOfertasActivasRequest() { idUsuario=idUsuario});
            return HelperResult.Result(result);
        }
        [HttpPut("borrar-oferta-activa")]
        public async Task<IActionResult> PutDeleteOfertaActiva(DeleteOfertaTrabajoActivaRequest request)
        {
            var result = await this.mediator.Send(request);
            return HelperResult.Result(result);
        }
        [HttpGet("obtener-ofertas-revision")]
        public async Task<IActionResult> GetOfertasRevision(int idUsuario)
        {
            var result = await this.mediator.Send(new GetEmpresaOfertasRevisionRequest() { idUsuario = idUsuario });
            return HelperResult.Result(result);
        }
        [HttpGet("obtener-ofertas-historial")]
        public async Task<IActionResult> GetOfertasHistorial(int idUsuario)
        {
            var result = await this.mediator.Send(new GetEmpresaOfertasHistorialRequest() { idUsuario = idUsuario });
            return HelperResult.Result(result);
        }
        [HttpGet("obtener-detalles-oferta")]
        public async Task<IActionResult> GetDetallesOferta(int idOferta)
        {
            var result = await this.mediator.Send(new GetOfertasTrabajoDetalleRequest() { idOferta = idOferta });
            return HelperResult.Result(result);
        }

    }
}
