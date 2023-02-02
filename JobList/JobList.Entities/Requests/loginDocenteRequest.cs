using JobList.Entities.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Requests
{
    public class LoginDocenteRequest : IRequest<LoginDocenteResponse>
    {
        public string usuario { get; set; } = default!;
        public string password { get; set; } = default!;
    }
}
