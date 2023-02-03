namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoPostulacionesRequest : IRequest<IEnumerable<GetEgresadoPostulacionesResponse>>
    {
        public int idUsuario { get; set; }
    }
}
