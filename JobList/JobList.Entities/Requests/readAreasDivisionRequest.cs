using JobList.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Requests
{
    public class readAreasDivisionRequest : IRequest<List<Area>>
    {
        public int idDivision { get; set; }
    }
}
