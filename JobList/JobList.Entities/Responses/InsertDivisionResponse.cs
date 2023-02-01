namespace JobList.Entities.Responses
{
    public class InsertDivisionResponse
    {
        public int idDivision { get; set; }
        public string descripcion { get; set; } = default!;
        public string mensaje { get; set; } = default!;
    }
}
