namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using MediatR;
    public class ReadOfertasPublicadasEmpresaRequest : Pagination, IRequest<List<ReadOfertasPublicadasEmpresaResponse>>
    {
        public int idUsuarioEmpresa { get; set; }
    }
}
