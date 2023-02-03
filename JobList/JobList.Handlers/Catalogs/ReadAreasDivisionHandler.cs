using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Catalogs
{
    public class ReadAreasDivisionHandler : IRequestHandler<ReadAreasDivisionRequest, List<ReadAreasDivisionResponse>>
    {
        private readonly IAreasUTPService areasUTPService;

        public ReadAreasDivisionHandler(IAreasUTPService areasUTPService)
        {
            this.areasUTPService = areasUTPService;
        }

        public async Task<List<ReadAreasDivisionResponse>> Handle(ReadAreasDivisionRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<ReadAreasDivisionResponse> listAreas = await this.areasUTPService.readAreasDivision(request);
            return listAreas.ToList();
        }
    }
}
