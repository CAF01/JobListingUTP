using JobList.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Services.Service
{
    public interface IGenerosService
    {
        public Task<IEnumerable<ReadGenerosResponse>> readGeneros();
    }
}
