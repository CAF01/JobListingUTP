namespace JobList.Entities.Responses
{
    public class InsertHabilidadResponse
    {
        public int idHabilidad { get; set; }
        public string descripcion { get; set; } = default!;
        public string mensaje { get; set; } = default!;
    }
}
