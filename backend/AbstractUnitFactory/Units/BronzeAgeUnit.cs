using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units;

public class BronzeAgeUnit : Unit
{
    protected override float DamageMultiplier => 1.2f;
    protected override float KillRewardMultiplier => 1.5f;
    protected override float CostMultiplier => 1.4f;

    private bool leveledUp = false;
    public override string Type => leveledUp ? "LevelUpUnit" : $"BronzeAge{UnitType.Name}";

    public override void UpdateUnits()
    {
        leveledUp = true;
    }
}