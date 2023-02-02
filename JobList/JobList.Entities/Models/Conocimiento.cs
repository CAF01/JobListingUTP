using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Models
{
    public class Conocimiento
    {
        public int idConocimiento { get; set; }
        public string descripcion { get; set; }
        public int contadorSeleccion { get; set; }
        public bool banderaEliminar { get; set; }
    }
}
