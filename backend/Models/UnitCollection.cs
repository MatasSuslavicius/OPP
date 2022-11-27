using System.Collections;
using tower_battle.AbstractUnitFactory.Units;

namespace tower_battle.Models;

public class UnitCollection : IEnumerable<Unit>
{
    private ICollection<Unit> Units { get; set; } = new List<Unit>();
    
    public void Add(Unit unit)
    {
        Units.Add(unit);
    }
    
    public void Remove(Unit unit)
    {
        Units.Remove(unit);
    }
    
    public void Clear()
    {
        Units.Clear();
    }
    
    public IEnumerator<Unit> GetEnumerator()
    {
        foreach(var unit in Units)
        {
            yield return unit;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}