namespace Solutionkitchen.Model;

public class Mesa
{
    public int NumeroMesa { get; set; }
    public List<PessoaNaMesa> Pessoa { get; set; }

    public Mesa(int numeroMesa)
    {
        NumeroMesa = numeroMesa;
        Pessoa = new List<PessoaNaMesa>();
    }

    public void AdicionarPessoa(PessoaNaMesa pessoa)
    {
        Pessoa.Add(pessoa);
    }

    public List<Pedido> ObterTodosOsPedidos()
    {
        return Pessoa.SelectMany(p => p.Pedidos).ToList();
    }
}