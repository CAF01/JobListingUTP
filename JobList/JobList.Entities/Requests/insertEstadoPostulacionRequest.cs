namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class InsertEstadoPostulacionRequest : IRequest<InsertEstadoPostulacionResponse>
    {
        public string descripcion { get; set; } = default!;
    }
}
