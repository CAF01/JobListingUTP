namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEmpresaDetallesPostuladoRequest : IRequest<GetEmpresaDetallesPostuladoResponse>
    {
        public int idUsuario { get; set; }
    }
}
