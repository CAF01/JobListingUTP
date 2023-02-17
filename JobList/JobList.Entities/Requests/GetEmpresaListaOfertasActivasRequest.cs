namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEmpresaListaOfertasActivasRequest : Pagination, IRequest<PaginationListResponse<GetEmpresaListaOfertasActivasResponse>>
    {
        public int idUsuario { get; set; }
    }
}
