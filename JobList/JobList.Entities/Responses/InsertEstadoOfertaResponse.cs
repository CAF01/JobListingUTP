namespace JobList.Entities.Responses
{
    public class InsertEstadoOfertaResponse
    {
        public int idEstadoOferta { get; set; }
        public string descripcion { get; set; } = default!;
        public string mensaje { get; set; } = default!;
    }
}
