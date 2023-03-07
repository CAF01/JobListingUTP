using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Services.Service;
using MediatR;

namespace JobList.Handlers.Catalogs
{
    public class ReadAreasDivisionHandler : IRequestHandler<ReadAreasDivisionRequest, IEnumerable<ReadAreasDivisionResponse>>
    {
        private readonly IAreasUTPService areasUTPService;

        public ReadAreasDivisionHandler(IAreasUTPService areasUTPService)
        {
            this.areasUTPService = areasUTPService;
        }

        public async Task<IEnumerable<ReadAreasDivisionResponse>> Handle(ReadAreasDivisionRequest request, CancellationToken cancellationToken)
        {
            return await this.areasUTPService.readAreasDivision(request);
        }
    }
}
