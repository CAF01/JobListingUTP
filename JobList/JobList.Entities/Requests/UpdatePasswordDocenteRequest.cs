using JobList.Entities.Responses;
using MediatR;

namespace JobList.Entities.Requests
{
    public class UpdatePasswordDocenteRequest : IRequest<UpdatePasswordDocenteResponse>
    {
        public int idUsuario { get; set; }
        public string password { get; set; }
    }
}
