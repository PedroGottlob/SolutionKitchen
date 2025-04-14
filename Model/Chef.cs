namespace Solutionkitchen.Model;

public class Chef :Funcionario
{
    string Especialidade { get; set; }

    public Chef(int id,string nome,TipoDeFuncionario tipo, string especialidade)
    {
        Id = id;
        Especialidade = especialidade;
        Nome = nome;
        Tipo=tipo;
    }
} 