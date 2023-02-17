namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class GetEmpresaOfertasHistorialRequest : Pagination, IRequest<PaginationListResponse<GetEmpresaOfertasHistorialResponse>>
    {
        public int idUsuario { get; set; }
    }
}
