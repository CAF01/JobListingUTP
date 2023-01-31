using System.ComponentModel.DataAnnotations;

namespace JobList.Entities.Requests
{
    public class insertEstadoOfertaRequest
    {
        [Required]
        public string descripcion { get; set; }

        public int idNuevoEstadoOferta { get; set; }
    }
}
