namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class InsertOfertaTrabajoExternaRequest : IRequest<InsertOfertaTrabajoResponse>
    {
        public string descripcionPuesto { get; set; } = default!;
        public int idArea { get; set; }
        public string periodoContrato { get; set; } = default!;
        public string modalidad { get; set; } = default!;
        public string horarioTrabajo { get; set; } = default!;
        public float sueldoMinEstimado { get; set; }
        public float suelodMaxEstimado { get; set; }
        public string lugar { get; set; } = default!;
        public DateTime fechaCreacion { get; set; }
        public IEnumerable<HabilidadOferta> habilidades { get; set; } = default!;
        public IEnumerable<ConocimientoOferta> conocimientos { get; set; } = default!;
        public IEnumerable<ResponsabilidadOferta> responsabilidades { get; set; } = default!;
        public IEnumerable<BeneficioOferta> beneficios { get; set; } = default!;
        public int idUsuario { get; set; }
        public DetallesContacto detallesContacto { get; set; } = default!;
    }

    public class DetallesContacto
    {
        public string empresa { get; set; } = default!;
        public string actividadEmpresa { get; set; } = default!;
        public string domicilio { get; set; } = default!;
        public string CP { get; set; } = default!;
        public string telefonos { get; set; } = default!;
        public string correoEmpresa { get; set; } = default!;
        public string descripcionEmpresa { get; set; } = default!;
        public string nombreResponsable { get; set; } = default!;
        public string telefonoResponsable { get; set; } = default!;
        public string correoResponsable { get; set; } = default!;
        public string imgUrl { get; set; } = default!;
    }
}
