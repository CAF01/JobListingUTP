namespace JobList.Handlers.Docente
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Resources;
    using JobList.Services.Service;
    using MediatR;
    public class InsertDocenteHandler : IRequestHandler<InsertDocenteRequest, InsertDocenteResponse>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public InsertDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }
        public async Task<InsertDocenteResponse> Handle(InsertDocenteRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaDocenteService.addDocente(request);
            if(result>0)
            {
                return new InsertDocenteResponse()
                {
                     idUsuario= result,
                     nombre=request.nombre,
                     usuario=request.usuario,
                     mensaje=ValidationResources.successInsert
                };
            }
            return new InsertDocenteResponse()
            {
                idUsuario = result,
                nombre = request.nombre,
                usuario = request.usuario,
                mensaje = ValidationResources.failInsert
            };
        }
    }
}
