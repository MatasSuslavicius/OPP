namespace tower_battle.AbstractUnitFactory.Units;

public class StoneAgeUnit : Unit
{
    protected override float DamageMultiplier => 1.1f;
    protected override float KillRewardMultiplier => 1.3f;
    protected override float CostMultiplier => 1.3f;
    private bool leveledUp = false;
    public override string Type => leveledUp ? "LevelUpUnit" : $"StoneAge{UnitType.Name}";

        public override void UpdateUnits()
    {
        leveledUp = true;
    }
}