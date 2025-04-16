using Solutionkitchen.Model;
using Solutionkitchen.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<PedidoService>();
builder.Services.AddSingleton<AdmService>();

var app = builder.Build();
{
    // Criar a lista de mesas
    var listaDeMesas = new List<Mesa>();
    var mesaService = new MesaService(listaDeMesas);

    // Criar mesa 6
    var mesa6 = new Mesa(6);

    // Criar pessoas
    var lucas = new PessoaNaMesa("Lucas");
    var pedro = new PessoaNaMesa("Pedro");

    // Criar pedidos, associando as pessoas aos pedidos
    var pedido1 = new Pedido(1, "Pizza", 1, 35.00, MetodoPagamento.Pix, lucas);
    var pedido2 = new Pedido(2, "Cachorro Quente", 2, 12.50, MetodoPagamento.CartaoDebito, pedro);

    // Associar pedidos às pessoas
    lucas.FazerPedido(pedido1);
    pedro.FazerPedido(pedido2);

    // Associar pessoas à mesa
    mesa6.AdicionarPessoa(lucas);
    mesa6.AdicionarPessoa(pedro);

    // Adicionar mesa ao serviço
    mesaService.AdicionarMesa(mesa6);

    // Obter o total da mesa 6 (sem segregação por pessoa)
    double totalMesa6 = mesaService.ObterTotalMesa(6);
    Console.WriteLine($"\nTotal da Mesa {mesa6.NumeroMesa}: R${totalMesa6:F2}");

    // Exibir pedidos da mesa 6
    var pedidosMesa6 = mesaService.ObterPedidosMesa(6);
    foreach (var pedido in pedidosMesa6)
    {
        Console.WriteLine($"Mesa: {mesa6.NumeroMesa} | Pessoa: {pedido.Pessoa.Nome} | Pedido: {pedido.Prato} | Quantidade: {pedido.Quantidade} | Valor: R${pedido.Quantidade * pedido.PrecoUnitario:F2} | Pagamento: {pedido.MetodoPagamento} | Status: {pedido.Status}");
    }
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();