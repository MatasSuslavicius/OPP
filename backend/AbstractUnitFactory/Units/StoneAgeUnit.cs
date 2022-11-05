namespace tower_battle.AbstractUnitFactory.Units;

public class StoneAgeUnit : Unit
{
    protected override float DamageMultiplier => 1.1f;
    protected override float KillRewardMultiplier => 1.3f;
    protected override float CostMultiplier => 1.3f;
    
    public override void UpdateUnits()
    {
        this.Type = "LevelUpUnit";
    }
}