namespace tower_battle.AbstractUnitFactory.Units;

public class BronzeAgeUnit : Unit
{
    protected override float DamageMultiplier => 1.2f;
    protected override float KillRewardMultiplier => 1.5f;
    protected override float CostMultiplier => 1.4f;
    
    public override void UpdateUnits()
    {
        this.Type = "LevelUpUnit";
    }
}