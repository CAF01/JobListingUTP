namespace JobList.Entities.Models
{
    public class ReadOfertasNuevasAdministradorResponse
    {
        public int idOferta { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string descripcionPuesto { get; set; } = default!;
        public string empresa { get; set; } = default!;
        public string nombreResponsable { get; set; } = default!;
    }
}
