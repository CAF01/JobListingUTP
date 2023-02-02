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
    public class ReadHabilidadesHandler : IRequestHandler<readHabilidadesRequest, List<Habilidad>>
    {
        private readonly IHabilidadesService habilidadesService;

        public ReadHabilidadesHandler(IHabilidadesService habilidadesService)
        {
            this.habilidadesService = habilidadesService;
        }

        // Obtener lista de habilidades
        public async Task<List<Habilidad>> Handle(readHabilidadesRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Habilidad> listHabilidades = await this.habilidadesService.readHabilidades();
            return listHabilidades.ToList();
        }
    }
}
