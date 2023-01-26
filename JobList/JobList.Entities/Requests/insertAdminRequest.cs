using System.ComponentModel.DataAnnotations;

namespace JobList.Entities.Requests
{
    public class insertAdminRequest
    {
        [Required]
        public string usuario { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string nombre { get; set; }

        public readonly int idTipo = 1;
        public int idNuevoUsuario { get; set; }
        public int idNuevoAdministrador { get; set; }
    }
}
