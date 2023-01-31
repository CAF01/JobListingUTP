using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Catalogs
{
    public class InsertDivisionHandler : IRequestHandler<InsertDivisionRequest, InsertDivisionResponse>
    {
        private readonly IAreasUTPService areasUTPService;

        public InsertDivisionHandler(IAreasUTPService areasUTPService)
        {
            this.areasUTPService = areasUTPService;
        }

        public async Task<InsertDivisionResponse> Handle(InsertDivisionRequest request, CancellationToken cancellationToken)
        {
            var result = await this.areasUTPService.addDivision(request);
            if (result > 0)
            {
                return new InsertDivisionResponse
                {
                    idDivision = result,
                    descripcion = request.descripcion,
                    mensaje = ValidationResources.successInsert
                };
            }
            else
            {
                return new InsertDivisionResponse
                {
                    idDivision = result,
                    descripcion = request.descripcion,
                    mensaje = ValidationResources.failInsert
                };
            }
        }
    }
}
