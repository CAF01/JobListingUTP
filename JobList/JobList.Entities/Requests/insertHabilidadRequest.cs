namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class InsertHabilidadRequest : IRequest<InsertHabilidadResponse>
    {
        public string descripcion { get; set; } = default!;
    }
}
