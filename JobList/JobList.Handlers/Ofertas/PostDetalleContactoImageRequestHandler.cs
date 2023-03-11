namespace JobList.Handlers.Ofertas
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class PostDetalleContactoImageRequestHandler : IRequestHandler<PostDetalleContactoImageRequest, PostEmpresaImageResponse>
    {
        private readonly IFilesService filesService;

        public PostDetalleContactoImageRequestHandler(IFilesService filesService)
        {
            this.filesService = filesService;
        }
        public async Task<PostEmpresaImageResponse> Handle(PostDetalleContactoImageRequest request, CancellationToken cancellationToken)
        {
            return await this.filesService.uploadDetallesImg(request);
        }
    }
}
