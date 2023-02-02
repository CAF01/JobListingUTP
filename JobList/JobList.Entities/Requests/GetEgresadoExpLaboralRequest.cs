namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoExpLaboralRequest : IRequest<GetEgresadoExpLaboralResponse>
    {
        public int idUsuario { get; set; }
    }
}
