namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    public interface IFilesService
    {
        public Task<PostEgresadoImageResponse> uploadEgresadoImage(PostEgresadoImageRequest request);
        public Task<bool> deleteImageEgresado(string publicId);

        public Task<PostEmpresaImageResponse> uploadEmpresaImage(PostEmpresaImageRequest request);
        public Task<bool> deleteImageEmpresa(string publicId);

        public Task<PostEmpresaImageResponse> uploadDetallesImg(PostDetalleContactoImageRequest request);
    }
}
