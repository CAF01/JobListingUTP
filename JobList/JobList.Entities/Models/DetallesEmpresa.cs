using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Models
{
    public class DetallesEmpresa
    {
        public int idUsuario { get; set; }
        public string nombreEmpresa { get; set; }
        public string tamano { get; set; }
        public string giro { get; set; }
        public string domicilioFiscal { get; set; }
        public string telefonos { get; set; }
        public string tipo { get; set; }
        public string actividadPrincipal { get; set; }
        public string CP { get; set; }
        public string correoEmpresa { get; set; }
        public string descripcionEmpresa { get; set; }
        public string nombreResponsable { get; set; }
        public string telefonoResponsable { get; set; }
        public string correoResponsable { get; set; }
        public Boolean banderaEliminar { get; set; }
    }
}
