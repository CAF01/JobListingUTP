using JobList.Entities.Models;
using JobList.Entities.Requests;
using JobList.Entities.Responses;
using JobList.Resources;
using JobList.Services.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Handlers.Catalogs
{
    public class ReadAreasDivisionHandler : IRequestHandler<readAreasDivisionRequest, List<Area>>
    {
        private readonly IAreasUTPService areasUTPService;

        public ReadAreasDivisionHandler(IAreasUTPService areasUTPService)
        {
            this.areasUTPService = areasUTPService;
        }

        public async Task<List<Area>> Handle(readAreasDivisionRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Area> listAreas = await this.areasUTPService.readAreasDivision(request);
            return listAreas.ToList();
        }
    }
}
