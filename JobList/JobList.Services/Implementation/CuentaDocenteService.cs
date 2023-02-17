namespace JobList.Services.Implementation
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Framework;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using JobList.Services.Service;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class CuentaDocenteService : ICuentaDocenteService
    {
        private readonly ICuentaDocenteRepository cuentaDocenteRepository;

        // Constructor
        public CuentaDocenteService(ICuentaDocenteRepository cuentaDocenteRepository)
        {
            this.cuentaDocenteRepository = cuentaDocenteRepository;
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
            //Registrar ultimo acceso
            await this.cuentaDocenteRepository.updateUltimoAccesoSistema(result.idUsuario);

            //Crear token
            result.token = this.CreateToken(userLogin.usuario.ToUpper(), result.idUsuario);
            return result;
        }

        // Crear token para usuario
        public string CreateToken(string usuario, int idUsuario)
        {
            var jti = Guid.NewGuid().ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfigResources.keyJWT);
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
        public async Task<PaginationListResponse<ReadHistorialOfertasDocenteResponse>> readHistorialOfertasDocente(ReadHistorialOfertasDocenteRequest request)
        {
            return await this.cuentaDocenteRepository.readHistorialOfertasDocente(request);
        }

        // Listado de ofertas en revisión de un docente
        public async Task<PaginationListResponse<ReadOfertasRevisionDocenteResponse>> readOfertasRevisionDocente(ReadOfertasRevisionDocenteRequest request)
        {
            return await this.cuentaDocenteRepository.readOfertasRevisionDocente(request);
        }

        // Listado de ofertas activas de un docente
        public async Task<PaginationListResponse<ReadOfertasActivasDocenteResponse>> readOfertasActivasDocente(ReadOfertasActivasDocenteRequest request)
        {
            return await this.cuentaDocenteRepository.readOfertasActivasDocente(request);
        }        

        // Actualizar contraseña de la cuenta de un usuario docente
        public async Task<UpdatePasswordDocenteResponse> updatePassword(UpdatePasswordDocenteRequest request)
        {
            request.password = PasswordEncryptor.GetMD5(request.password);
            return await this.cuentaDocenteRepository.updatePassword(request);
        }

        // Insertar una oferta de trabajo
        public async Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoExternaRequest request)
        {
            request.fechaCreacion = MexicoDateHelper.obtainDate();
            return await this.cuentaDocenteRepository.insertOfertaTrabajo(request);
        }
    }
}
