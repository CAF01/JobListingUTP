using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Models
{
    public class OfertaNuevaAdministrador
    {
        public int idOferta { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string descripcionPuesto { get; set; }
        public string empresa { get; set; }
        public string nombreResponsable { get; set; }
    }
}
