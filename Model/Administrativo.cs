namespace Solutionkitchen.Model;

public class Administrativo :Funcionario
{
    private int totalDePratosVendidos { get; set; }
    private double totalArrecadado { get; set; }
    
    public Administrativo(string nome, string cpf, string email, string telefone, string cep, string cidade, string estado,TipoDeFuncionario tipo): 
    base(nome, cpf, email, telefone, cep, cidade, estado, tipo)
    {
        totalDePratosVendidos = totalDePratosVendidos;
        totalArrecadado = totalArrecadado;

    }
}