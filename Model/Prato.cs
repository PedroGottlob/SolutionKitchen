namespace Solutionkitchen.Model;

public class Prato
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public Prato(int id, string nome, string descricao)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
    }
}