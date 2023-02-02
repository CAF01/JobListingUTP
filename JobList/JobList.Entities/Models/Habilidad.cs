using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Models
{
    public class Habilidad
    {
        public int idHabilidad { get; set; }
        public string descripcion { get; set; }
        public int contadorSeleccion { get; set; }
        public bool banderaEliminar { get; set; }
    }
}
