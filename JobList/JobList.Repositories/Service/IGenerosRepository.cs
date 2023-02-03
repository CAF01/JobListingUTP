using JobList.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Repositories.Service
{
    public interface IGenerosRepository
    {
        public Task<IEnumerable<ReadGenerosResponse>> readGeneros();
    }
}
