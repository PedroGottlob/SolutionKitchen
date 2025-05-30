namespace Solutionkitchen.Model;

public abstract class Funcionario()
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cep { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public TipoDeFuncionario Tipo { get; protected set; }
}