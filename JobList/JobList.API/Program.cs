using JobList.Repositories.Implementation;
using JobList.Repositories.Service;
using JobList.Services.Implementation;
using JobList.Services.Service;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Dictionary<string, IDbConnection> connections = new Dictionary<string, IDbConnection>
{
    { "DefaultConnection", new MySqlConnection(Configuration.GetConnectionString("DefaultConnection")) },
    { "SecondaryConnection", new MySqlConnection(Configuration.GetConnectionString("SecondaryConnection")) }
};

builder.Services.AddSingleton(connections);


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



//Tamara


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
