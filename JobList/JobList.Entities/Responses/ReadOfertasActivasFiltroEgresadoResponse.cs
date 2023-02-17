namespace JobList.Entities.Responses
{
    public class ReadOfertasActivasFiltroEgresadoResponse
    {
        public int postulantes { get; set; }
        public int idOferta { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public string descripcionPuesto { get; set; }
        public string descripcionEmpresa { get; set; }
        public string empresa { get; set; }
        public string domicilio { get; set; }
        public string area { get; set; }
        public string division { get; set; }
        public string semaforo { get; set; }
    }
}
