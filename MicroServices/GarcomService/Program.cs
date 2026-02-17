using GarcomService.Models;
using GarcomService.Services;
using GarcomService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços necessários para Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra serviços
builder.Services.AddScoped<GarcomServiceImpl>();

// Registra GarcomDbContext com SQL Server
builder.Services.AddDbContext<GarcomDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GarcomConnection")));

var app = builder.Build();

// Habilita Swagger e redireciona para ele automaticamente
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Garcom Service API v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
