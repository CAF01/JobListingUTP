namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEmpresaOfertasHistorialRequest : IRequest<IEnumerable<GetEmpresaOfertasHistorialResponse>>
    {
        public int idUsuario { get; set; }
    }
}
