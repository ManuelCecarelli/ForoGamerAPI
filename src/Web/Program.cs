using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Middleware;
using Infrastructure.Services;
using Infrastructure.Services.Mapping;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region SwaggerConfig

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

#endregion

#region DataBaseConfig

// DB connection String
string connectionString = builder.Configuration["ConnectionStrings:ForoGamerApiDbDefaultConnection"]!;

// Configure the SQLite connection
var connection = new SqliteConnection(connectionString);
connection.Open();

// Set journal mode to DELETE using PRAGMA statement
using (var command = connection.CreateCommand())
{
    command.CommandText = "PRAGMA journal_mode = DELETE;";
    command.ExecuteNonQuery();
}

builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions => dbContextOptions.UseSqlite(connectionString));

#endregion

#region AutoMapperConfig

builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); // Automapper

#endregion

#region Services

builder.Services.AddScoped<IMapperService, MapperService>(); //Servicio de mapeo entidades/dtos
builder.Services.AddScoped<IGenreService, GenreService>();

#endregion

#region Repositories

builder.Services.AddScoped<IGenreRepository, GenreRepository>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
