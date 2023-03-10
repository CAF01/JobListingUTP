namespace JobList.Entities.Requests
{
    using JobList.Entities.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class PostDetalleContactoImageRequest : IRequest<PostEmpresaImageResponse>
    {
        public IFormFile file { get; set; } = default!;
    }
}
