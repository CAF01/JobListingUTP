namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class updateEmpresaFotoRequest : IRequest<updateEmpresaFotoResponse>
    {
        public int idUsuario { get; set; }
        public string path { get; set; } = default!;
    }
}
