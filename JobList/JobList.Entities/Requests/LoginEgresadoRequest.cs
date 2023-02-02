namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class LoginEgresadoRequest : IRequest<LoginEgresadoResponse>
    {
        public string usuario { get; set; } = default!;
        public string password { get; set; } = default!;
    }
}
