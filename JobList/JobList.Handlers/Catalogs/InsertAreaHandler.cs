using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Catalogs
{
    public class InsertAreaHandler : IRequestHandler<InsertAreaRequest, InsertAreaResponse>
    {
        private readonly IAreasUTPService areasUTPService;

        public InsertAreaHandler(IAreasUTPService areasUTPService)
        {
            this.areasUTPService = areasUTPService;
        }

        public async Task<InsertAreaResponse> Handle(InsertAreaRequest request, CancellationToken cancellationToken)
        {
            var result = await this.areasUTPService.addArea(request);
            if (result > 0)
            {
                return new InsertAreaResponse
                {
                    idArea = result,
                    descripcion = request.descripcion,
                    mensaje = ValidationResources.successInsert
                };
            }
            else
            {
                return new InsertAreaResponse
                {
                    idArea = result,
                    descripcion = request.descripcion,
                    mensaje = ValidationResources.failInsert
                };
            }
        }
    }
}
