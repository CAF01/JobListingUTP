using System.ComponentModel.DataAnnotations;

namespace JobList.Entities.Requests
{
    public class insertEgresadoRequest
    {
        [Required]
        public string usuario { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string apellido { get; set; }

        public int idArea { get; set; }

        public readonly int idTipo = 2;
        public int idNuevoUsuario { get; set; }
        public int idNuevoEgresado { get; set; }
    }
}
