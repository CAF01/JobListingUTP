namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class PostEgresadoImageRequest : IRequest<PostEgresadoImageResponse>
    {
        public int idUsuario { get; set; }
        public IFormFile file { get; set; } = default!;
    }
}
