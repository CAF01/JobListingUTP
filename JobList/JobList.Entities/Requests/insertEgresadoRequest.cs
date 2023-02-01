namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class InsertEgresadoRequest : IRequest<InsertEgresadoResponse>
    {
        public string usuario { get; set; } = default!;
        public string password { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string apellido { get; set; } = default!;
        public int idArea { get; set; }
        public readonly int idTipo = 8;
    }
}
