namespace JobList.Entities.Responses
{
    public class GetEgresadoInfoPerfilResponse
    {
        public GetEgresadoInfoPersonalResponse personal { get; set; } = default!;
        public IEnumerable<GetEgresadoHabilidadesResponse> habilidades { get; set; } = default!;
        public IEnumerable<GetEgresadoConocimientosResponse> conocimientos { get; set; } = default!;
        public IEnumerable<GetEgresadoExpLaboralResponse> experienciasLaborales { get; set; } = default!;
    }
}
