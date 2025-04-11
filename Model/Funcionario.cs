namespace Solutionkitchen.Model;

public abstract class Funcionario(string nome, string cpf, string email, string telefone, string cep, string cidade, string estado, TipoDeFuncionario tipo)
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cep { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public TipoDeFuncionario tipo { get; protected set; }
}