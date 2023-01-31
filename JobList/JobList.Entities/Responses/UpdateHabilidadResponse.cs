namespace JobList.Entities.Responses
{
    public class UpdateHabilidadResponse
    {
        public int idHabilidad { get; set; }
        public string mensaje { get; set; } = default!;
        public bool success { get; set; }
    }
}
