namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class DeleteOfertaTrabajoActivaRequest : IRequest<DeleteOfertaTrabajoActivaResponse>
    {
        public int idOferta { get; set; }
    }
}
