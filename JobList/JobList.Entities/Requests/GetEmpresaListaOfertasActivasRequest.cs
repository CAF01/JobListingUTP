namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEmpresaListaOfertasActivasRequest : IRequest<IEnumerable<GetEmpresaListaOfertasActivasResponse>>
    {
        public int idUsuario { get; set; }
    }
}
