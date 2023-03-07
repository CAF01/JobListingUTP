namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using MediatR;
    public class ReadDetallesEmpresaRequest : IRequest<ReadDetallesEmpresaResponse>
    {
        public int idUsuarioEmpresa { get; set; }
    }
}
