namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class GetEgresadoBasicInfoHandler : IRequestHandler<GetEgresadoBasicInfoRequest, GetEgresadoBasicInfoResponse>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public GetEgresadoBasicInfoHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<GetEgresadoBasicInfoResponse> Handle(GetEgresadoBasicInfoRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEgresadoService.GetBasicInfo(request);
        }
    }
}
