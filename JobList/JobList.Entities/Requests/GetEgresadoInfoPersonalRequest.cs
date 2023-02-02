namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoInfoPersonalRequest : IRequest<GetEgresadoInfoPersonalResponse>
    {
        public int idUsuario { get; set; }
    }
}
