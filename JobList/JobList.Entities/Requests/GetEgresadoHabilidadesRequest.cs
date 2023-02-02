namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class GetEgresadoHabilidadesRequest : IRequest<GetEgresadoHabilidadesResponse>
    {
        public int idUsuario { get; set; }
    }
}
