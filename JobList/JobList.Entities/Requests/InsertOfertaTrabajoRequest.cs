namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class InsertOfertaTrabajoRequest : IRequest<InsertOfertaTrabajoResponse>
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
        public int idUsuarioEmpresa { get; set; }
    }

    public class HabilidadOferta
    {
        public int idHabilidad { get; set; }
    }

    public class ConocimientoOferta
    {
        public int idConocimiento { get; set; }
    }

    public class ResponsabilidadOferta
    {
        public int idOferta { get; set; }
        public string descripcion { get; set; } = default!;
    }

    public class BeneficioOferta
    {
        public int idOferta { get; set; }
        public string descripcion { get; set; } = default!;
    }
}
