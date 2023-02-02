using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Egresado
{
    public class GetEgresadoInfoPersonalHandler : IRequestHandler<GetEgresadoInfoPersonalRequest,GetEgresadoInfoPersonalResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public GetEgresadoInfoPersonalHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }

        public async Task<GetEgresadoInfoPersonalResponse> Handle(GetEgresadoInfoPersonalRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEgresadoService.getInfoEgresado(request);
        }
    }
}
