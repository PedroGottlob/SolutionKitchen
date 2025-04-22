using Solutionkitchen.Model;

namespace Solutionkitchen.Service;

public class MenuService
{
    private List<Prato> _pratosDoDia = new List<Prato>();

    public void DefinirPratosDoDia(List<Prato> pratos)
    {
        _pratosDoDia = pratos;
    }

    public List<Prato> ObterPratosDoDia()
    {
        return _pratosDoDia;
    }
}