namespace JobList.Entities.Responses
{
    public class UpdateConocimientoResponse
    {
        public string descripcion { get; set; } = default!;
        public string mensaje { get; set; } = default!;
        public bool success { get; set; }
    }
}
