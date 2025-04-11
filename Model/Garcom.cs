namespace Solutionkitchen.Model;

public class Garcom : Funcionario
{
    public int MesaResposavel { get; set; }
    
    public Garcom(string nome, string cpf, string email, string telefone, string cep, string cidade, string estado,TipoDeFuncionario tipo): 
        base(nome, cpf, email, telefone, cep, cidade, estado, tipo)
    {
        MesaResposavel = MesaResposavel;
    }
}