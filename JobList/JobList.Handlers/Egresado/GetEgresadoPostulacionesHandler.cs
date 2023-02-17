namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetEgresadoPostulacionesHandler : IRequestHandler<GetEgresadoPostulacionesRequest, PaginationListResponse<GetEgresadoPostulacionesResponse>>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public GetEgresadoPostulacionesHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }

        public async Task<PaginationListResponse<GetEgresadoPostulacionesResponse>> Handle(GetEgresadoPostulacionesRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEgresadoService.getPostulacionesEgresado(request);
        }
    }
}
