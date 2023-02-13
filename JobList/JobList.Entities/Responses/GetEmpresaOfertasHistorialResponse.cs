namespace JobList.Entities.Responses
{
    public class GetEmpresaOfertasHistorialResponse
    {
        public int idOferta { get; set; }
        public string lugar { get; set; } = default!;
        public string descripcionPuesto { get; set; } = default!;
        public string area { get; set; } = default!;
        public string division { get; set; } = default!;
        public string estadoOferta { get; set; } = default!;
    }
}
