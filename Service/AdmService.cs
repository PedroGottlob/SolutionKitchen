using Solutionkitchen.Model;

namespace Solutionkitchen.Service;

public class AdmService
{
    private List<Pedido> pedidosFinalizados = new();

    public void RegistrarVenda(Pedido pedido)
    {
        if (pedido.Status == "Finalizado")
            pedidosFinalizados.Add(pedido);
    }

    public double TotalArrecadado => pedidosFinalizados.Sum(p => p.CalcularValor());

    public int TotalPratos => pedidosFinalizados.Sum(p => p.Quantidade);

    
}
