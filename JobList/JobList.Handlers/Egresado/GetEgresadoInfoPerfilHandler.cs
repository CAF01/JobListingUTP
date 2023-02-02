namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;

    public class GetEgresadoInfoPerfilHandler : IRequestHandler<GetEgresadoInfoPerfilRequest, GetEgresadoInfoPerfilResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public GetEgresadoInfoPerfilHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<GetEgresadoInfoPerfilResponse> Handle(GetEgresadoInfoPerfilRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEgresadoService.getInfoPerfilEgresado(request);
        }
    }
}
