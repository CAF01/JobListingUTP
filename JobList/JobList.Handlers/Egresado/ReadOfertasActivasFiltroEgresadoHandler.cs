using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Egresado
{
    public class ReadOfertasActivasFiltroEgresadoHandler : IRequestHandler<ReadOfertasActivasFiltroEgresadoRequest, IEnumerable<ReadOfertasActivasFiltroEgresadoResponse>>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public ReadOfertasActivasFiltroEgresadoHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }

        public async Task<IEnumerable<ReadOfertasActivasFiltroEgresadoResponse>> Handle(ReadOfertasActivasFiltroEgresadoRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEgresadoService.readOfertasActivasFiltroEgresado(request);
        }
    }
}
