using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JobList.Entities.Requests
{
    public class insertAreaRequest
    {
        public string descripcion { get; set; } = default!;

        public int idDivision { get; set; }

        public int idNuevaArea { get; set; }
    }
}
