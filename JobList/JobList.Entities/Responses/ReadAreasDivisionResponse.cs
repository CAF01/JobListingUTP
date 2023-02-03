namespace JobList.Entities.Responses
{
    public class ReadAreasDivisionResponse
    {
        public int idArea { get; set; }
        public string descripcion { get; set; } = default!;
        public int idDivision { get; set; }
        public bool banderaEliminar { get; set; }
    }
}
