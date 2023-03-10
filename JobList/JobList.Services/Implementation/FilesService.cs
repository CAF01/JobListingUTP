namespace JobList.Services.Implementation
{
    using CloudinaryDotNet.Actions;
    using CloudinaryDotNet;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Services.Service;
    using System.Net;
    using System.Threading.Tasks;
    using JobList.Resources;
    using JobList.Entities.Enums;

    public class FilesService : IFilesService
    {
        Account account;
        ////private readonly CloudinaryConfig options;
        public FilesService()
        {
            this.account = new Account(ConfigResources.CName, ConfigResources.APK, ConfigResources.APS);
        }

        public async Task<bool> deleteImageEgresado(string publicId)
        {
            Cloudinary cloudinary = new Cloudinary(account);
            var newPath = publicId.Split('.');
            var result = await cloudinary.DeleteResourcesAsync($"{CloudinaryFolderType.Graduados}/{newPath[0]}");
            // Verifica que la foto se haya eliminado correctamente
            if (result.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<bool> deleteImageEmpresa(string publicId)
        {
            Cloudinary cloudinary = new Cloudinary(account);
            var newPath = publicId.Split('.');
            var result = await cloudinary.DeleteResourcesAsync($"{CloudinaryFolderType.Empresa}/{newPath[0]}");
            // Verifica que la foto se haya eliminado correctamente
            if (result.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        public async Task<PostEmpresaImageResponse> uploadDetallesImg(PostDetalleContactoImageRequest request)
        {
            try
            {
                PostEmpresaImageResponse response = new PostEmpresaImageResponse();

                Cloudinary cloudinary = new Cloudinary(account);

                ImageUploadParams uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(($"det-{Guid.NewGuid()}"), request.file.OpenReadStream()),
                    Folder = CloudinaryFolderType.Externo.ToString()
                };

                ImageUploadResult uploadResult = await Task.Run(() =>
                {
                    return cloudinary.Upload(uploadParams);
                });


                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
                    var cad = uploadResult.PublicId.ToString();
                    var array = cad.Split('/');
                    response.result = array[1] + "." + uploadResult.Format;
                    response.success = true;
                    return response;
                }
                return null;
            }
            catch
            {
                return null;

            }
        }

        public async Task<PostEgresadoImageResponse> uploadEgresadoImage(PostEgresadoImageRequest request)
        {
            try
            {
                PostEgresadoImageResponse response = new PostEgresadoImageResponse();

                Cloudinary cloudinary = new Cloudinary(account);

                ImageUploadParams uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(($"prof{request.idUsuario}-{Guid.NewGuid()}"), request.file.OpenReadStream()),
                    Folder = CloudinaryFolderType.Graduados.ToString()
                };

                ImageUploadResult uploadResult = await Task.Run(() =>
                {
                    return cloudinary.Upload(uploadParams);
                });


                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
                    var cad = uploadResult.PublicId.ToString();
                    var array = cad.Split('/');
                    response.result = array[1] + "." + uploadResult.Format;
                    response.success=true;
                    return response;
                }
                return null;
            }
            catch
            {
                return null;

            }
        }

        public async Task<PostEmpresaImageResponse> uploadEmpresaImage(PostEmpresaImageRequest request)
        {
            try
            {
                PostEmpresaImageResponse response = new PostEmpresaImageResponse();

                Cloudinary cloudinary = new Cloudinary(account);

                ImageUploadParams uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(($"prof{request.idUsuario}-{Guid.NewGuid()}"), request.file.OpenReadStream()),
                    Folder = CloudinaryFolderType.Empresa.ToString()
                };

                ImageUploadResult uploadResult = await Task.Run(() =>
                {
                    return cloudinary.Upload(uploadParams);
                });


                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
                    var cad = uploadResult.PublicId.ToString();
                    var array = cad.Split('/');
                    response.result = array[1] + "." + uploadResult.Format;
                    response.success = true;
                    return response;
                }
                return null;
            }
            catch
            {
                return null;

            }
        }
    }
}
