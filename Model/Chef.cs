using Solutionkitchen.Service;

namespace Solutionkitchen.Model;

public class Chef :Funcionario
{
    public string Especialidade { get; set; }
    private readonly MenuService _menuService;

    public Chef(int id,string nome,TipoDeFuncionario tipo, string especialidade,MenuService menuService)
    {
        Id = id;
        Especialidade = especialidade;
        Nome = nome;
        Tipo=tipo;
        _menuService = menuService;
    }
    public void DefinirPratosDoDia(List<Prato> pratos)
    {
        _menuService.DefinirPratosDoDia(pratos);
    }
} 