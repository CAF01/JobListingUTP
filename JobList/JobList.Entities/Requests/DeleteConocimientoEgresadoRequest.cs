namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class DeleteConocimientoEgresadoRequest : IRequest<DeleteConocimientoEgresadoResponse>
    {
        public int idUsuarioEgresado { get; set; }
        public int idConocimiento { get; set; }
    }
}
