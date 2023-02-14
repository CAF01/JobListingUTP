﻿namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;

    public class GetEgresadoListaOfertasHistorialHandler : IRequestHandler<GetEgresadoOfertasHistorialRequest, IEnumerable<GetEgresadoOfertasHistorialResponse>>
    {
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public GetEgresadoListaOfertasHistorialHandler(ICuentaEgresadoService cuentaEgresadoService)
        {
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<IEnumerable<GetEgresadoOfertasHistorialResponse>> Handle(GetEgresadoOfertasHistorialRequest request, CancellationToken cancellationToken)
        {
            return await this.cuentaEgresadoService.getOfertasHistorialEgresado(request);
        }
    }
}