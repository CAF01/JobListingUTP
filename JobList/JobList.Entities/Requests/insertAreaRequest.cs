namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class InsertAreaRequest : IRequest<InsertAreaResponse>
    {
        public string descripcion { get; set; } = default!;
        public int idDivision { get; set; } = default!;
    }
}
