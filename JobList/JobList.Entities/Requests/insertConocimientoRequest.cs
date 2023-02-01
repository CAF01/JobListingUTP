namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class InsertConocimientoRequest : IRequest<InsertConocimientoResponse>
    {
        public string descripcion { get; set; } = default!;
    }
}
