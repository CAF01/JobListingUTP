namespace JobList.Entities.Responses
{
    public class InsertConocimientoResponse
    {
        public int idConocimiento { get; set; }
        public string descripcion { get; set; } = default!;
        public string mensaje { get; set; } = default!;
    }
}
