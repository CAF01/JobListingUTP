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
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class CuentaAdministradorService : ICuentaAdministradorService
    {
        private readonly ICuentaAdministradorRepository cuentaAdministradorRepository;

        public IOptions<Entities.Models.Options> Options { get; }

        // Constructor
        public CuentaAdministradorService(ICuentaAdministradorRepository cuentaAdministradorRepository, IOptions<Entities.Models.Options> options)
        {
            this.cuentaAdministradorRepository = cuentaAdministradorRepository;
            Options = options;
        }

        // Insertar nuevo administrador
        public async Task<int> addAdministrador(InsertAdminRequest request)
        {
            request.password = PasswordEncryptor.GetMD5(request.password);

            return await this.cuentaAdministradorRepository.addAdministrador(request);
        }

        // Login administrador
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

        // Crear token para usuario
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

        // Listado de nuevas ofertas, esperando a ser validadas por el administrador
        public async Task<IEnumerable<ReadOfertasNuevasAdministradorResponse>> readOfertasNuevasAdministrador()
        {
            return await this.cuentaAdministradorRepository.readOfertasNuevasAdministrador();
        }

        // Listado de ofertas activas (de todos los usuarios)
        public async Task<IEnumerable<ReadOfertasActivasAdministradorResponse>> readOfertasActivasAdministrador()
        {
            return await this.cuentaAdministradorRepository.readOfertasActivasAdministrador();
        }

        // Listado de empresas afiliadas
        public async Task<IEnumerable<ReadEmpresasAfiliadasResponse>> readEmpresasAfiliadas()
        {
            return await this.cuentaAdministradorRepository.readEmpresasAfiliadas();
        }

        // Consultar los detalles de una empresa
        public async Task<IEnumerable<ReadDetallesEmpresaResponse>> readDetallesEmpresa(ReadDetallesEmpresaRequest request)
        {
            return await this.cuentaAdministradorRepository.readDetallesEmpresa(request);
        }

        // Listado de ofertas publicadas por una empresa (parte de los detalles de la empresa)
        public async Task<IEnumerable<ReadOfertasPublicadasEmpresaResponse>> readOfertasPublicadasEmpresa(ReadOfertasPublicadasEmpresaRequest request)
        {
            return await this.cuentaAdministradorRepository.readOfertasPublicadasEmpresa(request);
        }

        // Listado de seguimientos de postulaciones de todos los egresados
        public async Task<IEnumerable<ReadSeguimientosPostulacionEgresadosResponse>> readSeguimientosPostulacionEgresados()
        {
            return await this.cuentaAdministradorRepository.readSeguimientosPostulacionEgresados();
        }
    }
}
