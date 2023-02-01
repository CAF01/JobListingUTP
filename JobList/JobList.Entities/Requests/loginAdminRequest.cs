namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class LoginAdminRequest : IRequest<LoginAdminResponse>
    {
        public string usuario { get; set; } = default!;
        public string password { get; set; } = default!;
    }
}
