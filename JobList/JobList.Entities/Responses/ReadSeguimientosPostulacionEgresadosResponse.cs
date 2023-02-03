namespace JobList.Entities.Models
{
    public class ReadSeguimientosPostulacionEgresadosResponse
    {
        public int idPostulacion { get; set; }
        public int idEgresado { get; set; }
        public string matricula { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string estadoPostulacion { get; set; } = default!;
    }
}
