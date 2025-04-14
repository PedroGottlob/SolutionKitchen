namespace Solutionkitchen.Model;

public class Administrativo:Funcionario
{
    public string Cargo { get; set; }

    public Administrativo(int id, string nome, TipoDeFuncionario tipo, string cargo)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
        Cargo = cargo;
    }
}