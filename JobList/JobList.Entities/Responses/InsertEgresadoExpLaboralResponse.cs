namespace JobList.Entities.Responses
{
    public class InsertEgresadoExpLaboralResponse
    {
        public int  idExpLaboral{ get; set; }
        public bool success { get; set; }
        public string mensaje { get; set; } = default!;
    }
}
