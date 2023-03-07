namespace JobList.Entities.Responses
{
    public class GetEgresadoBasicInfoResponse
    {
        public int idUsuario { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string apellido { get; set; } = default!;
        public string generacion { get; set; } = default!;
        public int idArea { get; set; } = default!;
        public int idGenero { get; set; } = default!;
    }
}
