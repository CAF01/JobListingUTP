namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class DeleteEgresadoExpLaboralRequest : IRequest<DeleteEgresadoExpLaboralResponse>
    {
        public int idExperiencia { get; set; }
    }
}
