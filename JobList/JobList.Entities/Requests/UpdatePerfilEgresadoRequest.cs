namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class UpdatePerfilEgresadoRequest : IRequest<UpdatePerfilEgresadoResponse>
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

        public List<InsertConocimientoEgresadoRequest> ListConocimientosNuevos { get; set; } = default!;
        public List<InsertHabilidadEgresadoRequest> ListHabilidadesNuevas { get; set; } = default!;
        public List<InsertEgresadoExpLaboralRequest> ListExperienciaLaboralNuevas { get; set; } = default!;

        public List<DeleteConocimientoEgresadoRequest> ListConocimientosBorrar { get; set; } = default!;
        public List<DeleteHabilidadEgresadoRequest> ListHabilidadesBorrar { get; set; } = default!;
        public List<DeleteEgresadoExpLaboralRequest> ListExperienciaLaboralBorrar { get; set; } = default!;

    }
}
