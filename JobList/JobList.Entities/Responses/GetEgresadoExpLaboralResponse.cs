namespace JobList.Entities.Responses
{
    public class GetEgresadoExpLaboralResponse
    {
        public int idExperiencia { get; set; }
        public string empresa { get; set; } = default!;
        public string cargo { get; set; } = default!; 
        public string periodo { get; set; } = default!;
        public string salario { get; set; } = default!;
    }
}
