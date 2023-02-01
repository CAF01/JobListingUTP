namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class InsertAdminRequest : IRequest<InsertAdminResponse>
    {
        public string usuario { get; set; } = default!;
        public string password { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public readonly int idTipo = 5;
    }
}
