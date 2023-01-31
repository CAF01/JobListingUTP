using System.ComponentModel.DataAnnotations;

namespace JobList.Entities.Requests
{
    public class insertEstadoPostulacionRequest
    {
        public string descripcion { get; set; }

        public int idNuevoEstadoPostulacion { get; set; }
    }
}
