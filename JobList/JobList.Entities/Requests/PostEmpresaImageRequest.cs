namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    public class PostEmpresaImageRequest : IRequest<PostEmpresaImageResponse>
    {
        public int idUsuario { get; set; }
        public IFormFile file { get; set; } = default!;
    }
}
