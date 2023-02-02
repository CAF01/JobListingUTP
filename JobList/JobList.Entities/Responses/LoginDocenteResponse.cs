using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Responses
{
    public class LoginDocenteResponse
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string token { get; set; } = default!;
        public bool success { get; set; }
    }
}
