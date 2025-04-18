using Solutionkitchen.Model;
using Solutionkitchen.Service;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços necessários para Razor Pages e Controllers
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Registra serviços com dependências corretamente
builder.Services.AddSingleton<PedidoService>();
builder.Services.AddSingleton(new MesaService(new List<Mesa>()));
builder.Services.AddSingleton(new ChefService(new List<Pedido>()));
builder.Services.AddSingleton<MenuService>();
builder.Services.AddSingleton<GarcomService>();
builder.Services.AddSingleton<AdmService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapControllers(); // <- necessário para as APIs funcionarem

app.Run();
