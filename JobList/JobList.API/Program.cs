using FluentValidation;
using FluentValidation.AspNetCore;
using JobList.Entities.Models;
using JobList.Entities.Requests;
using JobList.Framework.Validations.Administrador;
using JobList.Handlers.Catalogs;
using JobList.Repositories.Implementation;
using JobList.Repositories.Service;
using JobList.Resources;
using JobList.Services.Implementation;
using JobList.Services.Service;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Configuration = builder.Configuration;

builder.Services.AddControllers();
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region modificaciones de inyección

builder.Services.AddMediatR(typeof(InsertDivisionRequest).Assembly);
builder.Services.AddMediatR(typeof(InsertDivisionHandler).GetTypeInfo().Assembly);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<InsertAdminValidation>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigResources.keyJWT))
        };
    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});


Dictionary<string, IDbConnection> connections = new Dictionary<string, IDbConnection>
    {
        { ConfigResources.DefaultConnection, new MySqlConnection(Configuration.GetConnectionString(ConfigResources.DefaultConnection)) },
        { ConfigResources.SecondaryConnection, new MySqlConnection(Configuration.GetConnectionString(ConfigResources.SecondaryConnection)) }
    };

builder.Services.AddSingleton(connections);

builder.Services.Configure<ConfigurationPaging>(Configuration.GetSection(ConfigResources.PaginationConfig));

#endregion


#region scopeds
//Christian
builder.Services.AddScoped<IAreasUTPService, AreasUTPService>();
builder.Services.AddScoped<IAreasUTPRepository, AreasUTPRepository>();
builder.Services.AddScoped<IEstadosOfertaService, EstadosOfertaService>();
builder.Services.AddScoped<IEstadosOfertaRepository, EstadosOfertaRepository>();
builder.Services.AddScoped<ICuentaAdministradorService, CuentaAdministradorService>();
builder.Services.AddScoped<ICuentaAdministradorRepository, CuentaAdministradorRepository>();
builder.Services.AddScoped<IEstadosPostulacionService, EstadosPostulacionService>();
builder.Services.AddScoped<IEstadosPostulacionRepository, EstadosPostulacionRepository>();
builder.Services.AddScoped<IHabilidadesService, HabilidadesService>();
builder.Services.AddScoped<IHabilidadesRepository, HabilidadesRepository>();
builder.Services.AddScoped<IConocimientosService, ConocimientosService>();
builder.Services.AddScoped<IConocimientosRepository, ConocimientosRepository>();
builder.Services.AddScoped<ICuentaDocenteService, CuentaDocenteService>();
builder.Services.AddScoped<ICuentaDocenteRepository, CuentaDocenteRepository>();
builder.Services.AddScoped<ICuentaEgresadoService, CuentaEgresadoService>();
builder.Services.AddScoped<ICuentaEgresadoRepository, CuentaEgresadoRepository>();



//Tamara
builder.Services.AddScoped<ITiposUsuarioService, TiposUsuarioService>();
builder.Services.AddScoped<ITiposUsuarioRepository, TiposUsuarioRepository>();
builder.Services.AddScoped<IGenerosService, GenerosService>();
builder.Services.AddScoped<IGenerosRepository, GenerosRepository>();
builder.Services.AddScoped<ICuentaEmpresaService, CuentaEmpresaService>();
builder.Services.AddScoped<ICuentaEmpresaRepository, CuentaEmpresaRepository>();

#endregion

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}


//app.UseCors("CorsPolicy");

//app.UseHttpsRedirection();

app.UseRouting(); //agregados
app.UseAuthentication(); //agregado JWT
app.UseAuthorization(); //ya estaba
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
}); //agregado

app.MapControllers();

app.Run();
