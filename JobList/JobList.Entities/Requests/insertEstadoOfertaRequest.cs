namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class InsertEstadoOfertaRequest : IRequest<InsertEstadoOfertaResponse>
    {
        public string descripcion { get; set; } = default!;
    }
}
