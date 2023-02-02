namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class DeleteHabilidadEgresadoRequest : IRequest<DeleteHabilidadEgresadoResponse>
    {
        public int idUsuarioEgresado { get; set; }
        public int idHabilidad { get; set; }
    }
}
