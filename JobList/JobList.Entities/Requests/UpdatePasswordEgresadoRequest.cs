namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class UpdatePasswordEgresadoRequest : IRequest<UpdatePasswordEgresadoResponse>
    {
        public int idUsuario { get; set; }
        public string password { get; set; }
    }
}
