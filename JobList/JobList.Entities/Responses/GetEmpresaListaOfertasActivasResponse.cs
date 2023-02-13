namespace JobList.Entities.Responses
{
    public class GetEmpresaListaOfertasActivasResponse
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
}
