namespace Solutionkitchen.Model;

public class Pedido
{
    public int Id { get; set; }
    public string Prato { get; set; }
    public int Quantidade { get; set; }
    public double PrecoUnitario { get; set; }
    public MetodoPagamento MetodoPagamento { get; set; }
    public string Status { get; set; } = "Pendente";

    public double CalcularValor() => Quantidade * PrecoUnitario;
}
