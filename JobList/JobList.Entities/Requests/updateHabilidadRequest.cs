namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class UpdateHabilidadRequest : IRequest<UpdateHabilidadResponse>
    {
        public string nuevaDescripcion { get; set; } = default!;
        public int idHabilidad { get; set; }
    }
}
