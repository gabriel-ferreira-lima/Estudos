using DependencyStore.Extensions;
using DependencyStore.Repository;
using DependencyStore.Repository.Contracts;
using DependencyStore.Services;
using DependencyStore.Services.Contracts;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<Configuration>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlConnection(connectionString);
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();