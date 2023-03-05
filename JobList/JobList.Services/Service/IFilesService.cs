namespace JobList.Services.Service
{
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    public interface IFilesService
    {
        public Task<PostEgresadoImageResponse> uploadEgresadoImage(PostEgresadoImageRequest request);
        public Task<bool> deleteImageEgresado(string publicId);
    }
}
