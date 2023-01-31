namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class InsertConocimientoEgresadoRequest : IRequest<InsertConocimientoEgresadoResponse>
    {
        public int idUsuarioEgresado { get; set; }
        public int idConocimiento { get; set; }
    }
}
