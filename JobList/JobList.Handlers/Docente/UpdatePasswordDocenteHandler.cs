using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Docente
{
    public class UpdatePasswordDocenteHandler : IRequestHandler<UpdatePasswordDocenteRequest, UpdatePasswordDocenteResponse>
    {
        private readonly ICuentaDocenteService cuentaDocenteService;

        public UpdatePasswordDocenteHandler(ICuentaDocenteService cuentaDocenteService)
        {
            this.cuentaDocenteService = cuentaDocenteService;
        }

        public async Task<UpdatePasswordDocenteResponse> Handle(UpdatePasswordDocenteRequest request, CancellationToken cancellationToken)
        {
            var result = await this.cuentaDocenteService.updatePassword(request);
            if (result == null)
            {
                return new UpdatePasswordDocenteResponse()
                {
                    mensaje = ValidationResources.failUpdate,
                    success = false
                };
            }
            if (result.success)
            {
                result.mensaje = ValidationResources.successUpdate;
            }
            if (result.EqualPassword)
            {
                result.mensaje = ValidationResources.equalPassword;
            }
            return result;
        }
    }
}
