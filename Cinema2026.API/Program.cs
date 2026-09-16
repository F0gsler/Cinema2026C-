using Cinema2026.Repo.Data;
using Cinema2026.Repo.Interfaces;
using Cinema2026.Repo.Repositiories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args); // Laver/Builder Web app

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnect")));

builder.Services.AddScoped<IPersonRepositories, PersonRepositories>();
builder.Services.AddScoped<IMovieHallRepositories, MovieHallRepositories>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // Laver en variable til kalde Bulder.Build()

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
