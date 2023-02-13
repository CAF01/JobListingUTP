namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class InsertEmpresaRequest : IRequest<InsertEmpresaResponse>
    {
        public string usuario { get; set; } = default!;
        public string password { get; set; } = default!;
        public string nombreResponsable { get; set; } = default!;
        public string nombreEmpresa { get; set; } = default!;
    }
}
