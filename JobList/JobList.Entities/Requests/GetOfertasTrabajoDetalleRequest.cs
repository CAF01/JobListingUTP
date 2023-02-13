namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class GetOfertasTrabajoDetalleRequest : IRequest<GetOfertasTrabajoDetalleResponse>
    {
        public int idOferta { get; set; }
    }
}
