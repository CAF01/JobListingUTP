namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class DeleteConocimientoRequest : IRequest<DeleteConocimientoResponse>
    {
        public int idConocimiento { get; set; }
    }
}
