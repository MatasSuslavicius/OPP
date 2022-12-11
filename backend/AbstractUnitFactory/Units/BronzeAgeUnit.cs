using tower_battle.Models;
using tower_battle.Observer;

namespace tower_battle.AbstractUnitFactory.Units;

public class BronzeAgeUnit : Unit
{
    //public override float DamageMultiplier => 1.2f;
    public override float DamageMultiplier
    {
        get => 1.2f;
        set {}
    }
    protected override float KillRewardMultiplier => 1.5f;
    protected override float CostMultiplier => 1.4f;

    
    public override string Type => leveledUp ? "LevelUpUnit" : $"BronzeAge{UnitType.Name}";

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}