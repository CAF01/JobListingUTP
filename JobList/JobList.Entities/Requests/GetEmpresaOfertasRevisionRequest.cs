namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEmpresaOfertasRevisionRequest : Pagination, IRequest<PaginationListResponse<GetEmpresaOfertasRevisionResponse>>
    {
        public int idUsuario { get; set; }
    }
}
