namespace Solutionkitchen.Model;

public class Chef :Funcionario
{
    string Especialidade { get; set; }

    public Chef(string nome, string cpf, string email, string telefone, string cep, string cidade, string estado,
        TipoDeFuncionario tipo) : base(
        nome, cpf, email, telefone, cep, cidade, estado, tipo)
    {
        Especialidade = Especialidade;
    }
} 