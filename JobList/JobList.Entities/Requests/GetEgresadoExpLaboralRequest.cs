namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEgresadoExpLaboralRequest : Pagination, IRequest<GetEgresadoExpLaboralResponse>
    {
        public int idUsuario { get; set; }
    }
}
