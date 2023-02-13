using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Responses
{
    public class UpdatePasswordDocenteResponse
    {
        public bool success { get; set; }
        public string mensaje { get; set; } = default!;
        public bool EqualPassword { get; set; }
    }
}
