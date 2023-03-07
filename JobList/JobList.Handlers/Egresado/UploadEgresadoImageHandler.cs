namespace JobList.Handlers.Egresado
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using MediatR;
    public class UploadEgresadoImageHandler : IRequestHandler<PostEgresadoImageRequest, PostEgresadoImageResponse>
    {
        private readonly IFilesService filesService;
        private readonly ICuentaEgresadoService cuentaEgresadoService;

        public UploadEgresadoImageHandler(IFilesService filesService,ICuentaEgresadoService cuentaEgresadoService)
        {
            this.filesService = filesService;
            this.cuentaEgresadoService = cuentaEgresadoService;
        }
        public async Task<PostEgresadoImageResponse> Handle(PostEgresadoImageRequest request, CancellationToken cancellationToken)
        {
            var result = await this.filesService.uploadEgresadoImage(request);
            var ActualimgUrl = await this.cuentaEgresadoService.getUrlById(request.idUsuario);
            if(ActualimgUrl != null )
                await this.filesService.deleteImageEgresado(ActualimgUrl);
            if(result!=null && result.success)
            {
                var resultUpdate = await this.cuentaEgresadoService.updateFoto(new updateEgresadoFotoRequest()
                {
                    idUsuario = request.idUsuario,
                    path = result.result
                });
                if(resultUpdate!=null && resultUpdate.success)
                    return result;
            }
            return null;
        }
    }
}
