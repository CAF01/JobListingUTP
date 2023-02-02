namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoInfoPerfilRequest : IRequest<GetEgresadoInfoPerfilResponse>
    {
        public int idUsuario { get; set; }
    }
}
