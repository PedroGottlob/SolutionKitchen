using Solutionkitchen.Model;
using Solutionkitchen.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<PedidoService>();
builder.Services.AddSingleton<AdmService>();

var app = builder.Build();
{
    // Criar o serviço de pedidos
    var pedidoService = new PedidoService();

// Criar o garçom e vincular ao serviço de pedidos
    var garcomService = new GarcomService(pedidoService);

// Criar uma pessoa na mesa
    var pessoa = new PessoaNaMesa("Pedro");

// Criar um pedido para a pessoa
    var pedido1 = new Pedido(1, "Pizza", 1, 30.00, MetodoPagamento.Pix, pessoa);

// Criar outro pedido
    var pedido2 = new Pedido(2, "Cachorro Quente", 2, 12.50, MetodoPagamento.CartaoCredito, pessoa);

// Adicionar os pedidos usando o garçom
    garcomService.CriarPedido(pedido1);
    garcomService.CriarPedido(pedido2);

// Exibir os pedidos atuais
    Console.WriteLine("\n📋 Pedidos Atuais:");
    foreach (var pedido in pedidoService.ObterTodos())
    {
        Console.WriteLine($"ID: {pedido.Id} | {pedido.Prato} | Quantidade: {pedido.Quantidade} | R${pedido.CalcularValor():F2}");
    }

// Editar um pedido
    garcomService.EditarPedido(1, "Pizza Calabresa", 2, 35.00, MetodoPagamento.CartaoDebito);

// Exibir após edição
    Console.WriteLine("\n✏️ Após Edição do Pedido 1:");
    foreach (var pedido in pedidoService.ObterTodos())
    {
        Console.WriteLine($"ID: {pedido.Id} | {pedido.Prato} | Quantidade: {pedido.Quantidade} | R${pedido.CalcularValor():F2}");
    }

// Remover um pedido
    garcomService.RemoverPedido(2);

// Exibir após remoção
    Console.WriteLine("\n🗑️ Após Remoção do Pedido 2:");
    foreach (var pedido in pedidoService.ObterTodos())
    {
        Console.WriteLine($"ID: {pedido.Id} | {pedido.Prato} | Quantidade: {pedido.Quantidade} | R${pedido.CalcularValor():F2}");
    }

}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();