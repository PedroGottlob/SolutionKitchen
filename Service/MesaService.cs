using Solutionkitchen.Model;


namespace Solutionkitchen.Service;

public class MesaService
{
    private readonly List<Mesa> _mesas; 
    
    
    public MesaService(List<Mesa> mesas)
    {
        _mesas = mesas;
    }
    public void AdicionarMesa(Mesa mesa)
    {
        _mesas.Add(mesa);
    }

    public Mesa BuscarMesa(int numeroMesa)
    {
        return _mesas.FirstOrDefault(m=> m.NumeroMesa == numeroMesa);
    }

    public List<Pedido> ObterPedidosMesa(int numeroMesa)
    {
        var mesa = BuscarMesa(numeroMesa);

        if (mesa != null)
        {
            return mesa.ObterTodosOsPedidos();
        }
        else
        {
            return new List<Pedido>();
        }
    }
    public double ObterTotalMesa(int numeroMesa)
    {
        var mesa = BuscarMesa(numeroMesa);
        if (mesa != null)
        {
            // Somar os valores de todos os pedidos da mesa
            return mesa.ObterTodosOsPedidos().Sum(p => p.Quantidade * p.PrecoUnitario);
        }
        return 0;
    }
    
}