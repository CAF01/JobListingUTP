namespace JobList.Entities.Responses
{
    public class InsertAdminResponse
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string mensaje { get; set; } = default!;
    }
}
