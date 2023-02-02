﻿namespace JobList.Services.Implementation
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

    public class CuentaEgresadoService : ICuentaEgresadoService
    {
        private readonly ICuentaEgresadoRepository cuentaEgresadoRepository;
        private readonly IOptions<Entities.Models.Options> options;

        public CuentaEgresadoService(ICuentaEgresadoRepository cuentaEgresadoRepository,IOptions<Entities.Models.Options> options)
        {
            this.cuentaEgresadoRepository = cuentaEgresadoRepository;
            this.options = options;
        }

        public async Task<int> addConocimientoEgresado(InsertConocimientoEgresadoRequest request)
        {
            return await this.cuentaEgresadoRepository.addConocimientoEgresado(request);
        }

        public async Task<int> addEgresado(InsertEgresadoRequest request)
        {
            request.password=PasswordEncryptor.GetMD5(request.password);
            return await this.cuentaEgresadoRepository.addEgresado(request);
        }

        public async Task<int> addHabilidadEgresado(InsertHabilidadEgresadoRequest request)
        {
            return await this.cuentaEgresadoRepository.addHabilidadEgresado(request);
        }

        public async Task<LoginEgresadoResponse> findEgresado(LoginEgresadoRequest request)
        {
            request.password = PasswordEncryptor.GetMD5(request.password);
            var result = await this.cuentaEgresadoRepository.findEgresado(request);
            if (result == null)
                return null;
            //Crear token
            result.token = this.CreateToken(request.usuario.ToUpper(), result.idUsuario);
            return result;
        }

        public string CreateToken(string usuario, int idUsuario)
        {
            var jti = Guid.NewGuid().ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(options.Value.ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario),
                    new Claim(ClaimTypes.Role, ConfigResources.RolEgresado),
                    new Claim(JwtRegisteredClaimNames.Jti,jti)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Audience = ConfigResources.EgresadoAudience,
                Issuer = ConfigResources.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(createdToken).ToString();
        }

        public async Task<UpdatePasswordEgresadoResponse> updatePassword(UpdatePasswordEgresadoRequest request)
        {
            request.password = PasswordEncryptor.GetMD5(request.password);
            return await this.cuentaEgresadoRepository.updatePassword(request);
        }

        public async Task<bool> updateDatosPersonales(UpdateEgresadoDatosPersonalesRequest request)
        {
            return await this.cuentaEgresadoRepository.updateDatosPersonales(request);
        }

        public async Task<int> addExperienciaLaboral(InsertEgresadoExpLaboralRequest request)
        {
            return await this.cuentaEgresadoRepository.addExperienciaLaboral(request);
        }

        public async Task<UpdatePerfilEgresadoResponse> updatePerfil(UpdatePerfilEgresadoRequest request)
        {
            return await this.cuentaEgresadoRepository.updatePerfil(request);
        }

        public async Task<GetEgresadoInfoPersonalResponse> getInfoEgresado(GetEgresadoInfoPersonalRequest request)
        {
            return await this.cuentaEgresadoRepository.getInfoEgresado(request);
        }

        public async Task<GetEgresadoInfoPerfilResponse> getInfoPerfilEgresado(GetEgresadoInfoPerfilRequest request)
        {
            return await this.cuentaEgresadoRepository.getInfoPerfilEgresado(request);
        }
    }
}
