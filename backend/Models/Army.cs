using Newtonsoft.Json;
using System.Collections;
using System.Text.Json.Serialization;
using tower_battle.AbstractUnitFactory.Units;

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
    public float TotalDamage { get; }
    public int UnitCount { get; }

    public List<IArmyUnit> Children = new()
    {
        new Legion
        {
            Name = "Soldier Legion"
        },
        new Legion
        {
            Name = "Scout Legion"
        },
        new Legion
        {
            Name = "Tank Legion"
        }
    };


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