namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class ReadOfertasPublicadasEmpresaRequest : Pagination, IRequest<PaginationListResponse<ReadOfertasPublicadasEmpresaResponse>>
    {
        public int idUsuarioEmpresa { get; set; }
    }
}
