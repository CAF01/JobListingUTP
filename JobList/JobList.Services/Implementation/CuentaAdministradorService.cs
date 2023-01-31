namespace JobList.Services.Implementation
{
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
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

    public class CuentaAdministradorService : ICuentaAdministradorService
    {
        private readonly ICuentaAdministradorRepository cuentaAdministradorRepository;

        public IOptions<Entities.Models.Options> Options { get; }

        public CuentaAdministradorService(ICuentaAdministradorRepository cuentaAdministradorRepository, IOptions<Entities.Models.Options> options)
        {
            this.cuentaAdministradorRepository = cuentaAdministradorRepository;
            Options = options;
        }
        public async Task<int> addAdministrador(InsertAdminRequest request)
        {
            request.password = PasswordEncryptor.GetMD5(request.password);

            return await this.cuentaAdministradorRepository.addAdministrador(request);
        }

        public async Task<AdminInfo> loginAdministradorConToken(LoginAdminRequest userLogin)
        {
            userLogin.password = PasswordEncryptor.GetMD5(userLogin.password);

            var result = await this.cuentaAdministradorRepository.findAdministrador(userLogin);
            if (result == null)
                return null;
            //Crear token
            result.token = this.CreateToken(userLogin.usuario.ToUpper(),result.idUsuario);
            return result;
        }

        public string CreateToken(string usuario,int idUsuario)
        {
            var jti = Guid.NewGuid().ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Options.Value.ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario),
                    new Claim(ClaimTypes.Role, ConfigResources.RolAdmin),
                    new Claim(JwtRegisteredClaimNames.Jti,jti)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Audience = ConfigResources.AdminAudience,
                Issuer = ConfigResources.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(createdToken).ToString();
        }
    }
}
