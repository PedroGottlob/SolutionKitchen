using Solutionkitchen.Model;
using Solutionkitchen.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<PedidoService>();
builder.Services.AddSingleton<AdmService>();

var app = builder.Build();

var menuService = new MenuService();

var chef = new Chef(1, "Carlos", TipoDeFuncionario.Chef, "Massas", menuService);
chef.DefinirPratosDoDia(new List<Prato>
{
    new Prato(1, "Lasanha", "Lasanha de carne com molho branco"),
    new Prato(2, "Risoto", "Risoto de cogumelos"),
    new Prato(1,"feijoada","feijoada de carne")
});

var garcom = new Garcom(2, "João", TipoDeFuncionario.Garcom, 5, menuService);
var pratosDisponiveis = garcom.VerPratosDisponiveis();

foreach (var prato in pratosDisponiveis)
{
    Console.WriteLine($"{prato.Nome} - {prato.Descricao}");
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();