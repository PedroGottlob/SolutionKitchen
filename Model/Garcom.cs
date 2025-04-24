using Solutionkitchen.Service;

namespace Solutionkitchen.Model;

public class Garcom : Funcionario
{
    public int MesaResposavel { get; set; }
    private readonly MenuService _menuService;

    public Garcom(int id, string nome, TipoDeFuncionario tipo, int mesaResposavel, MenuService menuService)
    {
        Id = id;
        MesaResposavel = mesaResposavel;
        Nome = nome;
        Tipo = tipo;
        _menuService = menuService;
    }

    public List<Prato> VerPratosDisponiveis()
    {
        return _menuService.ObterPratosDoDia();
    }
}