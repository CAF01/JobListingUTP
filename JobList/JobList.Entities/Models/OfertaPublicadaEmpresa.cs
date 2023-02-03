using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Models
{
    public class OfertaPublicadaEmpresa
    {
        public int idOferta { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public string area { get; set; }
        public string descripcionPuesto { get; set; }
        public string estadoVacante { get; set; }
    }
}
