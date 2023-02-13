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

        public IOptions<Entities.Models.ConfigModel> Options { get; }

        // Constructor
        public CuentaDocenteService(ICuentaDocenteRepository cuentaDocenteRepository, IOptions<Entities.Models.ConfigModel> options)
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
    }
}
