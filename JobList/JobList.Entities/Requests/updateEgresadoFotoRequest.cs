namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class updateEgresadoFotoRequest : IRequest<updateEgresadoFotoResponse>
    {
        public int idUsuario { get; set; }
        public string path { get; set; } = default!;
    }
}
