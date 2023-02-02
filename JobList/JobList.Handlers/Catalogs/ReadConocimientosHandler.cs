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
    public class ReadConocimientosHandler : IRequestHandler<readConocimientosRequest, List<Conocimiento>>
    {
        private readonly IConocimientosService conocimientosService;

        public ReadConocimientosHandler(IConocimientosService conocimientosService)
        {
            this.conocimientosService = conocimientosService;
        }

        // Obtener lista de conocimientos
        public async Task<List<Conocimiento>> Handle(readConocimientosRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Conocimiento> listConocimientos = await this.conocimientosService.readConocimientos();
            return listConocimientos.ToList();
        }
    }
}
