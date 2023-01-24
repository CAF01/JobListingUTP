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
