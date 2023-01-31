using System.ComponentModel.DataAnnotations;

namespace JobList.Entities.Requests
{
    public class insertEgresadoRequest
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }    
        public string apellido { get; set; }
        public int idArea { get; set; }
        public readonly int idTipo = 2;
        public int idNuevoUsuario { get; set; }
        public int idNuevoEgresado { get; set; }
    }
}
