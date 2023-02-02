using JobList.Entities.Models;
using JobList.Repositories.Service;
using JobList.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Services.Implementation
{
    public class GenerosService : IGenerosService
    {
        private readonly IGenerosRepository generosRepository;

        public GenerosService(IGenerosRepository generosRepository)
        {
            this.generosRepository = generosRepository;
        }

        public async Task<IEnumerable<Genero>> readGeneros()
        {
            return await this.generosRepository.readGeneros();
        }
    }
}
