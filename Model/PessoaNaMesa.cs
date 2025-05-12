namespace Solutionkitchen.Model;

public class PessoaNaMesa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Pedido> Pedidos { get; set; }

    
    public PessoaNaMesa(int id, string nome)
    {
        Id = id;
        Nome = nome;
        Pedidos = new List<Pedido>();
    }

    public void FazerPedido(Pedido pedido)
    {
        Pedidos.Add(pedido);
    }
}
