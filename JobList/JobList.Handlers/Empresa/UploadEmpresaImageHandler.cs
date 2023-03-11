namespace JobList.Handlers.Empresa
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    using System.Threading.Tasks;

    public class UploadEmpresaImageHandler : IRequestHandler<PostEmpresaImageRequest, PostEmpresaImageResponse>
    {
        private readonly IFilesService filesService;
        private readonly ICuentaEmpresaService cuentaEmpresaService;

        public UploadEmpresaImageHandler(IFilesService filesService, ICuentaEmpresaService cuentaEmpresaService)
        {
            this.filesService = filesService;
            this.cuentaEmpresaService = cuentaEmpresaService;
        }
        public async Task<PostEmpresaImageResponse> Handle(PostEmpresaImageRequest request, CancellationToken cancellationToken)
        {
            var result = await this.filesService.uploadEmpresaImage(request);
            var ActualimgUrl = await this.cuentaEmpresaService.getUrlById(request.idUsuario);
            if (ActualimgUrl != null)
                await this.filesService.deleteImageEmpresa(ActualimgUrl);
            if (result != null && result.success)
            {
                var resultUpdate = await this.cuentaEmpresaService.updateFoto(new updateEmpresaFotoRequest()
                {
                    idUsuario = request.idUsuario,
                    path = result.result
                });
                if (resultUpdate != null && resultUpdate.success)
                    return result;
            }
            return null;
        }
    }
}
