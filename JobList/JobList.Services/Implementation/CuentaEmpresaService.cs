using JobList.Entities.Models;
using JobList.Entities.Requests;
using JobList.Framework;
using JobList.Repositories.Service;
using JobList.Resources;
using JobList.Services.Service;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Services.Implementation
{
    public class CuentaEmpresaService : ICuentaEmpresaService
    {
        private readonly ICuentaEmpresaRepository cuentaEmpresaRepository;

        public IOptions<Entities.Models.Options> Options { get; }

        // Constructor
        public CuentaEmpresaService(ICuentaEmpresaRepository cuentaEmpresaRepository, IOptions<Entities.Models.Options> options)
        {
            this.cuentaEmpresaRepository = cuentaEmpresaRepository;
            Options = options;
        }

        // Login
        public async Task<EmpresaInfo> loginEmpresaConToken(LoginEmpresaRequest userLogin)
        {
            userLogin.password = PasswordEncryptor.GetMD5(userLogin.password);

            var result = await this.cuentaEmpresaRepository.findEmpresa(userLogin);
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
                    new Claim(ClaimTypes.Role, ConfigResources.RolEmpresa),
                    new Claim(JwtRegisteredClaimNames.Jti,jti)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Audience = ConfigResources.EmpresaAudience,
                Issuer = ConfigResources.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(createdToken).ToString();
        }
    }
}
