using Solutionkitchen.Model;
using Solutionkitchen.Service;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços necessários para Razor Pages, Controllers e Swagger
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra serviços com dependências corretamente
builder.Services.AddSingleton<PedidoService>();
builder.Services.AddSingleton(new MesaService(new List<Mesa>()));
builder.Services.AddSingleton(new ChefService(new List<Pedido>()));
builder.Services.AddSingleton<MenuService>();
builder.Services.AddSingleton<GarcomService>();
builder.Services.AddSingleton<AdmService>();


builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80); // Força o app a escutar em todas as interfaces no container
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Habilita Swagger e redireciona para ele automaticamente
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kitchen API v1");
    c.RoutePrefix = string.Empty; // faz com que o Swagger UI abra na raiz (localhost:7042/)
});

app.MapRazorPages();
app.MapControllers();

app.Run();