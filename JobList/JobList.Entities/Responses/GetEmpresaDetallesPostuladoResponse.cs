namespace JobList.Entities.Responses
{
    public class GetEmpresaDetallesPostuladoResponse
    {
        public string imgUrl { get; set; } = default!;
        public IEnumerable<HabilidadesEgresado> habilidades { get; set; } = default!;
        public IEnumerable<ConocimientosEgresado> conocimientos { get; set; } = default!;
        public IEnumerable<ExperienciasEgresado> experiencias { get; set; } = default!;
    }

    public class HabilidadesEgresado
    {
        public string descripcion { get; set; } = default!;
    }

    public class ConocimientosEgresado
    {
        public string descripcion { get; set; } = default!;
    }

    public class ExperienciasEgresado
    {
        public string empresa { get; set; } = default!;
        public string cargo { get; set; } = default!;
        public string periodo { get; set; } = default!;
    }
}
