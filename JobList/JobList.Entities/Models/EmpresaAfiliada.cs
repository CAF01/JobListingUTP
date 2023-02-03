using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Models
{
    public class EmpresaAfiliada
    {
        public int idUsuario { get; set; }
        public string imgUrl { get; set; }
        public string nombreEmpresa { get;}
        public string domicilioFiscal { get; set; }
        public Boolean banderaEliminar { get; set; }
    }
}
