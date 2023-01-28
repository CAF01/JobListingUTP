using System.ComponentModel.DataAnnotations;

namespace JobList.Entities.Requests
{
    public class insertHabilidadRequest
    {
        [Required]
        public string descripcion { get; set; }

        public int idNuevaHabilidad { get; set; }
    }
}
