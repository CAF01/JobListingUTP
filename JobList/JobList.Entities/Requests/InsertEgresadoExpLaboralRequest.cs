namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class InsertEgresadoExpLaboralRequest : IRequest<InsertEgresadoExpLaboralResponse>
    {
        public string empresa { get; set; } = default!;
        public string cargo { get; set; } = default!;
        public string periodo { get; set; } = default!;
        public float salario { get; set; }
        public int idUsuarioEgresado { get; set; }
    }
}
