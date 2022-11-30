using tower_battle.AbstractUnitFactory.Builder;
using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.AbstractUnitFactory.Units.Types;
using tower_battle.Models;
using tower_battle.Turrets.Decorator;

namespace tower_battle.Turrets;

public class TurretToUnitAdapter : Unit
{
    private ITurret turret;
    public TurretToUnitAdapter(ITurret turret)
    {
        this.turret = turret;
        UpdateTurretValues();
    }
    public override void UpdateUnits()
    {
    }

    protected override float DamageMultiplier => 1f;
    protected override float KillRewardMultiplier => 1f;
    protected override float CostMultiplier => 1f;

    public override string Type => "Turret";

    public void UpdateTurretValues()
    {
        Position = turret.Position;
        UnitType = new SoldierUnitTypeBuilder(new SoldierType{Scale = new Vector2 { X = turret.Range, Y = turret.Range }})
            .SetMovement(new NullMovementStrategy())
            .SetDamage(turret.Damage)
            .Build();
    }
}