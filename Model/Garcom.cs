namespace Solutionkitchen.Model;

public class Garcom : Funcionario
{
    public int MesaResposavel { get; set; }
    
    public Garcom(int id, string nome,TipoDeFuncionario tipo, int mesaResposavel)
    {
        Id = id;
        MesaResposavel = mesaResposavel;
        Nome = nome;
        Tipo=tipo;
    }
} 