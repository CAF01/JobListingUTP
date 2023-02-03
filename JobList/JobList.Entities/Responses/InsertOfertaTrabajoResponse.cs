namespace JobList.Entities.Responses
{
    public class InsertOfertaTrabajoResponse
    {
        public int idOferta { get; set; }
        public bool success { get; set; }
        public string mensaje { get; set; } = default!;
    }
}
