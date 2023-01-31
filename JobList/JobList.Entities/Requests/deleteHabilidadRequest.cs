namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class DeleteHabilidadRequest : IRequest<DeleteHabilidadResponse>
    {
        public int idHabilidad { get; set; }
    }
}
