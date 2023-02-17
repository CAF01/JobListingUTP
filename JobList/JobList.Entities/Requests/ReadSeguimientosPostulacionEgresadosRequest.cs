namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using MediatR;
    public class ReadSeguimientosPostulacionEgresadosRequest : Pagination,IRequest<List<ReadSeguimientosPostulacionEgresadosResponse>>
    {
    }
}
