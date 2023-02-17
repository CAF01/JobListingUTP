namespace JobList.Entities.Requests
{
    using JobList.Entities.Models;
    using MediatR;
    public class ReadEmpresasAfiliadasRequest : Pagination, IRequest<List<ReadEmpresasAfiliadasResponse>>
    {
    }
}
