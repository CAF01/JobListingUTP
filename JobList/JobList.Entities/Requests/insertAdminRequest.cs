using System.ComponentModel.DataAnnotations;

namespace JobList.Entities.Requests
{
    public class insertAdminRequest
    {
   
        public string usuario { get; set; }

   
        public string password { get; set; }

     
        public string nombre { get; set; }

        public readonly int idTipo = 5;
        public int idNuevoUsuario { get; set; }
        public int idNuevoAdministrador { get; set; }
    }
}
