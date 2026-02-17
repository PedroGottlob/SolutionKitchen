namespace Shared.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public List<PratoDto>? Prato { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public string Status { get; set; } = "Pendente";
        public int? MetodoPagamento { get; set; }
        public string? PessoaNome { get; set; }

        public double CalcularValor() => Quantidade * PrecoUnitario;
    }
}
