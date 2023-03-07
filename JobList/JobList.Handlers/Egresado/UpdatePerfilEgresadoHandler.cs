namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class UpdatePerfilEgresadoHandler : IRequestHandler<UpdatePerfilEgresadoRequest, UpdatePerfilEgresadoResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public UpdatePerfilEgresadoHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<UpdatePerfilEgresadoResponse> Handle(UpdatePerfilEgresadoRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaEgresadoService.updatePerfil(request);
            return new UpdatePerfilEgresadoResponse()
            {
                successPerfil = result.successPerfil,
                successConocimientos = result.successConocimientos,
                successDeleteConocimientos = result.successDeleteConocimientos,
                successDeleteExperienciaLaboral = result.successDeleteExperienciaLaboral,
                successDeleteHabilidades = result.successDeleteHabilidades,
                successExperiencias = result.successExperiencias,
                successHabilidades = result.successHabilidades,
                mensaje = ValidationResources.successUpdate
            };
        }
    }
}
