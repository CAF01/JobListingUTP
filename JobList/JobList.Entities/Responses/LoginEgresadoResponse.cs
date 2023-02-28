namespace JobList.Entities.Responses
{
    public class LoginEgresadoResponse
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; } = default!;
        public string apellido { get; set; } = default!;
        public bool statusPassword { get; set; }
        public bool camposVacios { get; set; }
        public string usuario { get; set; } = default!;
        public string token { get; set; } = default!;
        public bool success { get; set; }
        public string mensaje { get; set; } = default!;
    }
}
