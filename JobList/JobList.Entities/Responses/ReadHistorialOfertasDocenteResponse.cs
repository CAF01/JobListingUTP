using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Responses
{
    public class ReadHistorialOfertasDocenteResponse
    {
        public int idOferta { get; set; }
        public string lugar { get; set; }
        public string descripcionPuesto { get; set; }
        public string area { get; set; }
        public string division { get; set; }
        public string estadoOferta { get; set; }
    }
}
