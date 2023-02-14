namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;

    public class UpdateAdministradorOfertaValidacionRequest : IRequest<UpdateAdministradorOfertaValidacionResponse>
    {
        public int idOferta { get; set; }
        public bool estado { get; set; }
    }
}
