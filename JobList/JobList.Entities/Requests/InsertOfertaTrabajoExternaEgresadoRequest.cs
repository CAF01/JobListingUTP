namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class InsertOfertaTrabajoExternaEgresadoRequest : IRequest<InsertOfertaTrabajoResponse>
    {
        public string descripcionPuesto { get; set; } = default!;
        public int idArea { get; set; }
        public string periodoContrato { get; set; } = default!;
        public string modalidad { get; set; } = default!;
        public string horarioTrabajo { get; set; } = default!;
        public float sueldoMinEstimado { get; set; }
        public float sueldoMaxEstimado { get; set; }
        public string lugar { get; set; } = default!;
        public DateTime fechaCreacion { get; set; }
        public IEnumerable<HabilidadOferta> habilidades { get; set; } = default!;
        public IEnumerable<ConocimientoOferta> conocimientos { get; set; } = default!;
        public IEnumerable<ResponsabilidadOferta> responsabilidades { get; set; } = default!;
        public IEnumerable<BeneficioOferta> beneficios { get; set; } = default!;
        public int idUsuario { get; set; }
        public DetallesContacto detallesContacto { get; set; } = default!;
    }
}
