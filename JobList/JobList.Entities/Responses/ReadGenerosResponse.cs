namespace JobList.Entities.Models
{
    public class ReadGenerosResponse
    {
        public int idGenero { get; set; }
        public string descripcion { get; set; } = default!;
        public bool banderaEliminar { get; set; }
    }
}
