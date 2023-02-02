using JobList.Entities.Models;
using JobList.Entities.Requests;
using JobList.Services.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Handlers.Catalogs
{
    public class ReadDivisionesHandler : IRequestHandler<readDivisionesRequest, List<Division>>
    {
        private readonly IAreasUTPService areasUTPService;

        public ReadDivisionesHandler(IAreasUTPService areasUTPService)
        {
            this.areasUTPService = areasUTPService;
        }

        // Tarea para obtener lista de divisiones
        public async Task<List<Division>> Handle(readDivisionesRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Division> listDivisiones = await this.areasUTPService.readDivisiones();
            return listDivisiones.ToList();
        }
    }
}
