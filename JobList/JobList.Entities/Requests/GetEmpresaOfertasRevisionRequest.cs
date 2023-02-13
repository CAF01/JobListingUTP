namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEmpresaOfertasRevisionRequest : IRequest<IEnumerable<GetEmpresaOfertasRevisionResponse>>
    {
        public int idUsuario { get; set; }
    }
}
