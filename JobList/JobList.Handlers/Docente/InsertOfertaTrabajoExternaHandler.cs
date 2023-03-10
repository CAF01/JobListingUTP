﻿namespace JobList.Handlers.Docente
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class InsertOfertaTrabajoExternaHandler : IRequestHandler<InsertOfertaTrabajoExternaRequest, InsertOfertaTrabajoResponse>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public InsertOfertaTrabajoExternaHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<InsertOfertaTrabajoResponse> Handle(InsertOfertaTrabajoExternaRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaDocenteService.insertOfertaTrabajo(request);
            if (result != null && result.idOferta > 0)
            {
                return new InsertOfertaTrabajoResponse()
                {
                    idOferta = result.idOferta,
                    mensaje = ValidationResources.successInsert,
                    success = true
                };
            }
            return new InsertOfertaTrabajoResponse()
            {
                idOferta = -1,
                mensaje = ValidationResources.failInsert,
                success = false
            };
        }
    }
}
