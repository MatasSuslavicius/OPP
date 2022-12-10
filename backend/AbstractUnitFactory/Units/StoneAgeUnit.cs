using tower_battle.Observer;

namespace tower_battle.AbstractUnitFactory.Units;

public class StoneAgeUnit : Unit
{
    public override float DamageMultiplier
    {
        get => 1.1f;
        set { }
    }
    protected override float KillRewardMultiplier => 1.3f;
    protected override float CostMultiplier => 1.3f;
    
    public override string Type => leveledUp ? "LevelUpUnit" : $"StoneAge{UnitType.Name}";

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}