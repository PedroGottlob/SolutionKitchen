namespace Solutionkitchen.Model;

public class Pedido
{                                   
    public int Id { get; set; }
    public List<Prato> Prato { get; set; }
    public int Quantidade { get; set; }
    public double PrecoUnitario { get; set; }

    public string Status { get; set; } = "Pendente";
    public MetodoPagamento MetodoPagamento { get; set; }
    public PessoaNaMesa Pessoa { get; set; }

    public double CalcularValor() => Quantidade * PrecoUnitario;

    public Pedido(int id, List<Prato> pratos, int quantidade, double precoUnitario, MetodoPagamento metodoPagamento, PessoaNaMesa pessoa)
    {
        Id = id;
        Prato = pratos;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
        MetodoPagamento = metodoPagamento;
        Pessoa = pessoa;
    }
}