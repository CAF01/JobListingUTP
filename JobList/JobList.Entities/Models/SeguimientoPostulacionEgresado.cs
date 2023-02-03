using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Models
{
    public class SeguimientoPostulacionEgresado
    {
        public int idPostulacion { get; set; }
        public int idEgresado { get; set; }
        public string matricula { get; set; }
        public string nombre { get; set; }
        public string estadoPostulacion { get; set; }
    }
}
