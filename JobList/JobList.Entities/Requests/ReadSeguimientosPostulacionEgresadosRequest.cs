namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using JobList.Entities.Responses;
    using MediatR;
    public class ReadSeguimientosPostulacionEgresadosRequest : Pagination,IRequest<PaginationListResponse<ReadSeguimientosPostulacionEgresadosResponse>>
    {
    }
}
