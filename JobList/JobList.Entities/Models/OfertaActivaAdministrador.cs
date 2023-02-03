using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Models
{
    public class OfertaActivaAdministrador
    {
        public int idOferta { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public string descripcionPuesto { get; set; }
        public string empresa { get; set; }
        public string nombreResponsable { get; set; }
        public int numeroPostulantes { get; set; }
        public string semaforo { get; set; }
        public string estadoPostulacion { get; set; }
    }
}
