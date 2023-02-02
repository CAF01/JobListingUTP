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
    public class ReadGenerosHandler : IRequestHandler<readGenerosRequest, List<Genero>>
    {
        private readonly IGenerosService generosService;

        public ReadGenerosHandler(IGenerosService generosService)
        {
            this.generosService = generosService;
        }

        public async Task<List<Genero>> Handle(readGenerosRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Genero> listGeneros = await this.generosService.readGeneros();
            return listGeneros.ToList();
        }
    }
}
