namespace JobList.Entities.Models
{
    public class ReadHabilidadesResponse
    {
        public int idHabilidad { get; set; }
        public string descripcion { get; set; } = default!;
        public int contadorSeleccion { get; set; }
        public bool banderaEliminar { get; set; }
    }
}
