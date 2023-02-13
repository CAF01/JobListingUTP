namespace JobList.Services.Implementation
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Framework;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using JobList.Services.Service;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class CuentaDocenteService : ICuentaDocenteService
    {
        private readonly ICuentaDocenteRepository cuentaDocenteRepository;

        public IOptions<Entities.Models.Options> Options { get; }

        // Constructor
        public CuentaDocenteService(ICuentaDocenteRepository cuentaDocenteRepository, IOptions<Entities.Models.Options> options)
        {
            this.cuentaDocenteRepository = cuentaDocenteRepository;
            Options = options;
        }

        // Insertar nueva cuenta de usuario para docente
        public async Task<int> addDocente(InsertDocenteRequest request)
        {
            request.password = PasswordEncryptor.GetMD5(request.password);
            return await this.cuentaDocenteRepository.addDocente(request);
        }

        // Login 
        public async Task<LoginDocenteResponse> loginDocenteConToken(LoginDocenteRequest userLogin)
        {
            userLogin.password = PasswordEncryptor.GetMD5(userLogin.password);

            var result = await this.cuentaDocenteRepository.findDocente(userLogin);
            if (result == null)
                return null;

            //Crear token
            result.token = this.CreateToken(userLogin.usuario.ToUpper(), result.idUsuario);
            return result;
        }

        // Crear token para usuario
        public string CreateToken(string usuario, int idUsuario)
        {
            var jti = Guid.NewGuid().ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Options.Value.ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario),
                    new Claim(ClaimTypes.Role, ConfigResources.RolDocente),
                    new Claim(JwtRegisteredClaimNames.Jti,jti)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Audience = ConfigResources.DocenteAudience,
                Issuer = ConfigResources.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(createdToken).ToString();
        }

        // Historial de ofertas de un docente
        public async Task<IEnumerable<ReadHistorialOfertasDocenteResponse>> readHistorialOfertasDocente(ReadHistorialOfertasDocenteRequest request)
        {
            return await this.cuentaDocenteRepository.readHistorialOfertasDocente(request);
        }

        // Listado de ofertas en revisión de un docente
        public async Task<IEnumerable<ReadOfertasRevisionDocenteResponse>> readOfertasRevisionDocente(ReadOfertasRevisionDocenteRequest request)
        {
            return await this.cuentaDocenteRepository.readOfertasRevisionDocente(request);
        }

        // Listado de ofertas activas de un docente
        public async Task<IEnumerable<ReadOfertasActivasDocenteResponse>> readOfertasActivasDocente(ReadOfertasActivasDocenteRequest request)
        {
            return await this.cuentaDocenteRepository.readOfertasActivasDocente(request);
        }

        // Consultar detalles de una oferta de trabajo
        //public async Task<ReadDetallesOfertaResponse> readDetallesOferta(ReadDetallesOfertaRequest request)
        //{
        //    return await this.cuentaDocenteRepository.readDetallesOferta(request);
        //}

        // Eliminar una oferta activa
        public async Task<bool> deleteOfertaActiva(DeleteOfertaActivaDocenteRequest request)
        {
            return await this.cuentaDocenteRepository.deleteOfertaActiva(request);
        }

        // Actualizar contraseña de la cuenta de un usuario docente
        public async Task<UpdatePasswordDocenteResponse> updatePassword(UpdatePasswordDocenteRequest request)
        {
            request.password = PasswordEncryptor.GetMD5(request.password);
            return await this.cuentaDocenteRepository.updatePassword(request);
        }

        // Lista de postulantes de una oferta publicada por un docente
        public async Task<IEnumerable<ReadPostulacionesOfertaResponse>> readPostulacionesOferta(ReadPostulacionesOfertaRequest request)
        {
            return await this.cuentaDocenteRepository.readPostulacionesOferta(request);
        }
    }
}
