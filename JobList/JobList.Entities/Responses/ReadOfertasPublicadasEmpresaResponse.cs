namespace JobList.Entities.Models
{
    public class ReadOfertasPublicadasEmpresaResponse
    {
        public int idOferta { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public string area { get; set; } = default!;
        public string descripcionPuesto { get; set; } = default!;
        public string estadoVacante { get; set; } = default!;
    }
}
