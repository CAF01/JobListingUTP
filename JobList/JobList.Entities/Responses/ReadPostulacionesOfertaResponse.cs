using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Responses
{
    public class ReadPostulacionesOfertaResponse
    {
        public int idEgresado { get; set; }
        public DateTime fechaPostulacion { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string descripcionEgresado { get; set; }
        public int edad { get; set; }
        public string area { get; set; }
        public string division { get; set; }
    }
}
