using Newtonsoft.Json;
using System.Collections;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.Models.Flyweight;

namespace tower_battle.Models;

public enum LegionType
{
    Soldier = 0,
    Scout = 1,
    Tank = 2,
    Turret
}

[JsonObject]
public class Army : IArmyUnit, IEnumerable<Unit>
{
    public int UnitCount 
    {
        get
        {
            return Children.Sum(c => c.UnitCount);
        }
    }

    public List<IArmyUnit> Children = FlyweightFactory.GenerateBaseLegions();

    public void AddChild(IArmyUnit armyUnit)
    {
        Children.Add(armyUnit);
    }

    public void RemoveChild(IArmyUnit armyUnit)
    {
        Children.Remove(armyUnit);
    }


    public IEnumerator<IArmyUnit> GetEnumerator()
    {
        foreach (var child in Children)
        {
            if(child is Unit)
            {
                yield return child;
            }
            else
            {
                foreach(var grandChild in child)
                {
                    yield return grandChild;
                }
            }
        }
    }

    public List<Unit> GetUnitArray()
    {
        return ((IEnumerable<Unit>)this).ToList();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator<Unit> IEnumerable<Unit>.GetEnumerator()
    {
        foreach (var child in Children)
        {
            if (child is Unit)
            {
                yield return child as Unit;
            }
            else
            {
                foreach (var grandChild in child)
                {
                    yield return grandChild as Unit;
                }
            }
        }
    }
}