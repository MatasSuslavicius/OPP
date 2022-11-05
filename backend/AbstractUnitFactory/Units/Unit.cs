using tower_battle.Models;
using tower_battle.AbstractUnitFactory.Units.Types;

namespace tower_battle.AbstractUnitFactory.Units;

public abstract class Unit : Observer.Observer
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
    public int Cost => (int)(CostMultiplier * UnitType.Cost);

    public float Health
    {
        get => UnitType.Health;
        private set => UnitType.Health = value;
    }

    public float InitialHealth => UnitType.InitialHealth;

    public void DealDamage(Unit unit)
    {
        unit.Health -= Damage;
    }
}
