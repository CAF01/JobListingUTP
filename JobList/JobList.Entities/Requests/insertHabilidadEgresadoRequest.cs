namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class InsertHabilidadEgresadoRequest : IRequest<InsertHabilidadEgresadoResponse>
    {
        public int idUsuarioEgresado { get; set; }
        public int idHabilidad { get; set; }
    }
}
