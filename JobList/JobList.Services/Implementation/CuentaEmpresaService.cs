﻿namespace JobList.Services.Implementation
{
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
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
    public class CuentaEmpresaService : ICuentaEmpresaService
    {
        private readonly ICuentaEmpresaRepository cuentaEmpresaRepository;

        public IOptions<Entities.Models.ConfigModel> Options { get; }

        // Constructor
        public CuentaEmpresaService(ICuentaEmpresaRepository cuentaEmpresaRepository, IOptions<Entities.Models.ConfigModel> options)
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

        public async Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoRequest request)
        {
            request.fechaCreacion = MexicoDateHelper.obtainDate();
            return await this.cuentaEmpresaRepository.insertOfertaTrabajo(request);
        }

        public async Task<InsertEmpresaResponse> insertCuentaEmpresa(InsertEmpresaRequest request)
        {
            return await this.cuentaEmpresaRepository.insertCuentaEmpresa(request);
        }

        public async Task<UpdateEmpresaDatosResponse> updateDatosEmpresa(UpdateEmpresaDatosRequest request)
        {
            //Procedimiento para subir imagen a servicio
            return await this.cuentaEmpresaRepository.updateDatosEmpresa(request);
        }

        public async Task<IEnumerable<GetEmpresaListaOfertasActivasResponse>> getOfertasActivasEmpresa(GetEmpresaListaOfertasActivasRequest request)
        {
            return await this.cuentaEmpresaRepository.getOfertasActivasEmpresa(request);
        }

        public async Task<bool> SetStatusOfertaActivaBorrar(DeleteOfertaTrabajoActivaRequest request)
        {
            return await this.cuentaEmpresaRepository.SetStatusOfertaActivaBorrar(request);
        }

        public async Task<IEnumerable<GetEmpresaOfertasRevisionResponse>> getOfertasRevisionEmpresa(GetEmpresaOfertasRevisionRequest request)
        {
            return await this.cuentaEmpresaRepository.getOfertasRevisionEmpresa(request);
        }

        public async Task<IEnumerable<GetEmpresaOfertasHistorialResponse>> getOfertasHistorialEmpresa(GetEmpresaOfertasHistorialRequest request)
        {
            return await this.cuentaEmpresaRepository.getOfertasHistorialEmpresa(request);
        }

        public async Task<GetOfertasTrabajoDetalleResponse> GetDetallesOferta(GetOfertasTrabajoDetalleRequest request)
        {
            return await this.cuentaEmpresaRepository.GetDetallesOferta(request);
        }
    }
}
