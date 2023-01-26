using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JobList.Entities.Requests
{
    public class insertAreaRequest
    {
        [Required]
        public string descripcion { get; set; }

        [Required]
        public int idDivision { get; set; }

        public int idNuevaArea { get; set; }
    }
}
