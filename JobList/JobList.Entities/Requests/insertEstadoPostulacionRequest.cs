using System.ComponentModel.DataAnnotations;

namespace JobList.Entities.Requests
{
    public class insertEstadoPostulacionRequest
    {
        [Required]
        public string descripcion { get; set; }

        [Required]
        public int idNuevoEstadoPostulacion { get; set; }
    }
}
