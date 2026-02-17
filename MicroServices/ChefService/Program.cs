using ChefService.Models;
using ChefService.Services;
using ChefService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços necessários para Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra serviços
builder.Services.AddScoped<ChefServiceImpl>();

// Registra ChefDbContext com SQL Server
builder.Services.AddDbContext<ChefDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChefConnection")));

var app = builder.Build();

// Habilita Swagger e redireciona para ele automaticamente
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chef Service API v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
