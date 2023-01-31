namespace JobList.Entities.Responses
{
    public class InsertDocenteResponse
    {
        public int idUsuario { get; set; } = default!;
        public string usuario { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string mensaje { get; set; } = default!;
    }
}
