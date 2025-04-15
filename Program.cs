using Solutionkitchen.Model;
using Solutionkitchen.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<PedidoService>();
builder.Services.AddSingleton<AdmService>();

var app = builder.Build();

var pedidos = new List<Pedido>
{
    new Pedido { PedidoId = 1, Status = "Pendente" },
    new Pedido { PedidoId = 2, Status = "Pendente" },
    new Pedido { PedidoId = 3, Status = "Em Preparo" },
    new Pedido { PedidoId = 4, Status = "Pronto" }
};

ChefService chef = new ChefService(pedidos);
GarcomService garcom = new GarcomService();

chef.Pronto += garcom.PegarPrato;




app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();