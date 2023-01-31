namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class UpdateConocimientoRequest : IRequest<UpdateConocimientoResponse>
    {
        public string nuevaDescripcion { get; set; } = default!;
        public int idConocimiento { get; set; } = default!;
    }
}
