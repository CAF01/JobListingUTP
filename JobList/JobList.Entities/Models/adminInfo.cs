namespace JobList.Entities.Models
{
    public class AdminInfo
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; } = default!;
        public string token { get; set; } = default!;
    }
}
