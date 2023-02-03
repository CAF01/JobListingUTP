namespace JobList.Entities.Models
{
    public class ReadOfertasActivasAdministradorResponse
    {
        public int idOferta { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public string descripcionPuesto { get; set; } = default!;
        public string empresa { get; set; } = default!;
        public string nombreResponsable { get; set; } = default!;
        public int numeroPostulantes { get; set; }
        public string semaforo { get; set; } = default!;
        public string estadoPostulacion { get; set; } = default!;
    }
}
