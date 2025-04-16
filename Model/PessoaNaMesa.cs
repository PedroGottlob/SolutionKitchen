namespace Solutionkitchen.Model;

public class PessoaNaMesa
{
    public string Nome { get; set; }
    public List<Pedido> Pedidos { get; set; }

    public PessoaNaMesa(string nome)
    {
        Nome = nome;
        Pedidos = new List<Pedido>();
    }

    public void FazerPedido(Pedido pedido)
    {
        Pedidos.Add(pedido);
    }
}
