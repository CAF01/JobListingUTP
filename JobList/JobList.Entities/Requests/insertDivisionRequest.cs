namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class InsertDivisionRequest : IRequest<InsertDivisionResponse>
    {
        public string descripcion { get; set; } = default!;
    }
}
