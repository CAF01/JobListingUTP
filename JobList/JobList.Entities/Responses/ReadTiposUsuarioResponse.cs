namespace JobList.Entities.Models
{
    public class ReadTiposUsuarioResponse
    {
        public int idTipo { get; set; }
        public string descripcion { get; set; } = default!;
        public bool banderaEliminar { get; set; }
    }
}
