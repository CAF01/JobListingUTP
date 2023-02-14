namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoOfertasHistorialRequest : IRequest<IEnumerable<GetEgresadoOfertasHistorialResponse>>
    {
        public int idUsuario { get; set; }
    }
}
