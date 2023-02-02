namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class UpdateEgresadoDatosPersonalesRequest : IRequest<UpdateEgresadoDatosPersonalesResponse>
    {
        public int idUsuario { get; set; }
        public string correo { get; set; } = default!;
        public int genero { get; set; }
        public int edad { get; set; }
        public string telefono { get; set; } = default!;
        public string descripcionEgresado { get; set; } = default!;
        public int idArea { get; set; }
        public string imgUrl { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string apellido { get; set; } = default!;
        public string generacion { get; set; } = default!;
    }
}
