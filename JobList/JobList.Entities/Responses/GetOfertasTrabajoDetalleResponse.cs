namespace JobList.Entities.Responses
{
    public class GetOfertasTrabajoDetalleResponse
    {
        public int idOferta { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public string descripcionPuesto { get; set; } = default!;
        public string area { get; set; } = default!;
        public string division { get; set; } = default!;
        public string empresa { get; set; } = default!;
        public string lugar { get; set; } = default!;
        public string descripcionEmpresa { get; set; } = default!;
        public string modalidad { get; set; } = default!;
        public string horarioTrabajo { get; set; } = default!;
        public string periodoContrato { get; set; } = default!;
        public bool beneficiosRegistrados { get; set; }
        public bool sueldoRegistrado { get; set; }
        public string sueldoMinEstimado { get; set; } = default!;
        public string sueldoMaxEstimado { get; set; } = default!;
        public IEnumerable<BeneficiosOferta> beneficiosOferta { get; set; } = default!;
        public IEnumerable<HabilidadesOferta> habilidadesOferta { get; set; } = default!;
        public IEnumerable<ConocimientosOferta> conocimientosOferta { get; set; } = default!;
        public IEnumerable<ResponsabilidadesOferta> responsabilidadesOferta { get; set; } = default!;
    }

    public class BeneficiosOferta
    {
        public int idBeneficio { get; set; }
        public string descripcion { get; set; } = default!;
        public int idOferta { get; set; }
    }

    public class HabilidadesOferta
    {
        public int idHabilidad { get; set; }
        public string descripcion { get; set; } = default!;
        public int idOferta { get; set; }
    }

    public class ConocimientosOferta
    {
        public int idConocimiento { get; set; }
        public string descripcion { get; set; } = default!;
        public int idOferta { get; set; }
    }

    public class ResponsabilidadesOferta
    {
        public int idResponsabilidad { get; set; }
        public string descripcion { get; set; } = default!;
        public int idOferta { get; set; }
    }
}
