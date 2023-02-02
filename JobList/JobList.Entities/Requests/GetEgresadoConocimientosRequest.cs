namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoConocimientosRequest : IRequest<GetEgresadoConocimientosResponse>
    {
        public int idUsuario { get; set; }
    }
}
