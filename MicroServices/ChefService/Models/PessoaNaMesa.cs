namespace ChefService.Models;

public class PessoaNaMesa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int MesaId { get; set; }

    public PessoaNaMesa(int id, string nome, int mesaId)
    {
        Id = id;
        Nome = nome;
        MesaId = mesaId;
    }
}
