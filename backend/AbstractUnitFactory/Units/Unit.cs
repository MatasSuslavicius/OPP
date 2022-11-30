using tower_battle.Models;
using tower_battle.AbstractUnitFactory.Units.Types;
using System.Collections;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace tower_battle.AbstractUnitFactory.Units;

[JsonObject]
public abstract class Unit : Observer.Observer, IArmyUnit
{
    public abstract string Type { get; }
    public Vector2 Position { get; set; }
    public UnitType UnitType { get; set; }
    protected abstract float DamageMultiplier { get; }
    protected abstract float KillRewardMultiplier { get; }
    protected abstract float CostMultiplier { get; }

    public float KillReward => KillRewardMultiplier * UnitType.KillReward;
    public float Damage => DamageMultiplier * UnitType.Damage;
    public Vector2 Scale => UnitType.Scale;
    public int Cost => (int) (CostMultiplier * UnitType.Cost);

    public float Health
    {
        get => UnitType.Health;
        set => UnitType.Health = value;
    }

    public float InitialHealth => UnitType.InitialHealth;

    public void DealDamage(Unit unit)
    {
        unit.Health -= Damage;
    }

    public void AddChild(IArmyUnit armyUnit)
    {
        throw new NotImplementedException("Cannot add child army units to a unit");
    }

    public IEnumerator<IArmyUnit> GetEnumerator()
    {
        yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void RemoveChild(IArmyUnit armyUnit)
    {
        throw new NotImplementedException("Cannot remove child army units to a unit");
    }
}