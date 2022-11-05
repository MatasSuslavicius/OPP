using tower_battle.AbstractUnitFactory.Builder;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.AbstractUnitFactory.Units.Types;
using tower_battle.Models;

namespace tower_battle.Turrets;

public class TurretToUnitAdapter : Unit
{
    private Turret turret;
    public TurretToUnitAdapter(Turret turret)
    {
        this.turret = turret;
        Position = turret.Position;
        UnitType = new SoldierUnitTypeBuilder(new SoldierType{Scale = new Vector2 { X = turret.Range, Y = turret.Range }})
            .SetMovement(new NullMovementStrategy())
            .SetDamage(turret.Damage)
            .Build();
    }
    public override void UpdateUnits()
    {
    }

    public override string Type => "Turret";
    protected override float DamageMultiplier => 1f;
    protected override float KillRewardMultiplier => 1f;
    protected override float CostMultiplier => 1f;
}