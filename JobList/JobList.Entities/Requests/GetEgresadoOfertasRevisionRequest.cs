namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoOfertasRevisionRequest : IRequest<IEnumerable<GetEmpresaOfertasRevisionResponse>>
    {
        public int idUsuario { get; set; }
    }
}
