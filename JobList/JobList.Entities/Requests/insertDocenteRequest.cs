namespace JobList.Entities.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class insertDocenteRequest
    {
        [Required]
        public string usuario { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string nombre { get; set; }

        public readonly int idTipo = 3;
        public int idNuevoUsuario { get; set; }
        public int idNuevoDocente { get; set; }
    }
}
