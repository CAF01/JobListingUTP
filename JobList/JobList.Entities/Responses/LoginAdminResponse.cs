namespace JobList.Entities.Responses
{
    public class LoginAdminResponse
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string token { get; set; } = default!;
        public bool success { get; set; }
    }
}
