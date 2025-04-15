using Solutionkitchen.Model;
using Solutionkitchen.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<PedidoService>();
builder.Services.AddSingleton<AdmService>();

var app = builder.Build();

MetodoPagamento metodoPagamento = new MetodoPagamento();

var pedidos = new List<Pedido>
{
    new Pedido
    {
        PedidoId = 1, Prato = "Hambúrguer", Quantidade = 2, PrecoUnitario = 22.5, MetodoPagamento = MetodoPagamento.Pix
    },
    new Pedido
    {
        PedidoId = 2, Prato = "Pizza", Quantidade = 1, PrecoUnitario = 40.0,
        MetodoPagamento = MetodoPagamento.CartaoCredito
    },
    new Pedido
    {
        PedidoId = 3, Prato = "Lasanha", Quantidade = 1, PrecoUnitario = 30.0,
        MetodoPagamento = MetodoPagamento.Dinheiro, Status = "Em Preparo"
    }
};

var chefService = new ChefService(pedidos);

Console.WriteLine("🔍 Pedidos pendentes:");
foreach (var p in chefService.ListarPedidosPendentes())
{
    Console.WriteLine($"Pedido #{p.PedidoId} - {p.Prato} - Status: {p.Status}");
}

Console.WriteLine("\n👨‍🍳 Marcando pedido 1 como 'Em Preparo'...");
chefService.PedidoEmPreparo(1);

Console.WriteLine("\n✅ Marcando pedido 3 como 'Pronto'...");
chefService.PedidoPronto(3);

Console.WriteLine("\n📦 Situação final dos pedidos:");
foreach (var p in pedidos)
{
    Console.WriteLine($"Pedido #{p.PedidoId} - {p.Prato} - Status: {p.Status}");
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();