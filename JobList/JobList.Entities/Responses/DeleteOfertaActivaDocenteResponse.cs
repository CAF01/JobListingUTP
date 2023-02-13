using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Responses
{
    public class DeleteOfertaActivaDocenteResponse
    {
        public int idOferta { get; set; }
        public string mensaje { get; set; }
        public bool success { get; set; }
    }
}
