namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoListaOfertasActivasRequest : IRequest<IEnumerable<GetEgresadoListaOfertasActivasResponse>>
    {
        public int idUsuario { get; set; }
    }
}
