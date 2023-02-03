namespace JobList.Entities.Responses
{
    public class GetEgresadoListaOfertasActivasResponse
    {
        public int idOferta { get; set; }
        public string lugar { get; set; } = default!;
        public string descripcionPuesto { get; set; } = default!;
        public string area { get; set; } = default!;
        public string division { get; set; } = default!;
        public int postulantes { get; set; } = default!;
        public bool tienePostulantes { get; set; }
        public IEnumerable<PostulanteOferta> ListaPostulantes { get; set; } = default!;
    }

    public class PostulanteOferta
    {
        public int idPostulacion { get; set; }
        public int idUsuario { get; set; }
        public string nombre { get; set; } = default!;
        public string apellido { get; set; } = default!;
        public string descripcionEgresado { get; set; } = default!;
        public string edad { get; set; } = default!;
        public string division { get; set; } = default!;
        public string area { get; set; } = default!;
        public DateTime fechaPostulacion { get; set; }
    }

}
