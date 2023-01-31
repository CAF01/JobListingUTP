namespace JobList.Entities.Responses
{
    public class InsertEstadoPostulacionResponse
    {
        public int idEstadoPostulacion { get; set; }
        public string descripcion { get; set; } = default!;
        public string mensaje { get; set; } = default!;
    }
}
