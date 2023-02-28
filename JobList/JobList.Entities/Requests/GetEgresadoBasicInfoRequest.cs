namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoBasicInfoRequest : IRequest<GetEgresadoBasicInfoResponse>
    {
        public int idUsuario { get; set; }
    }
}
