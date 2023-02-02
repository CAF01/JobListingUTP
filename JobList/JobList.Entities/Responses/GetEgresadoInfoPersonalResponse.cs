namespace JobList.Entities.Responses
{
    public class GetEgresadoInfoPersonalResponse
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; } = default!;
        public string apellido { get; set; } = default!;
        public string correo { get; set; } = default!;
        public string genero { get; set; } = default!;
        public string edad { get; set; } = default!;
        public string telefono { get; set; } = default!;
        public string generacion { get; set; } = default!;
        public string descripcionEgresado { get; set; } = default!;
        public string imgUrl { get; set; } = default!;
        public string area { get; set; } = default!;
        public string especialidad { get; set; } = default!;
    }
}
