using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.Types;

public abstract class UnitType
{
    public abstract string Name { get; }
    public Vector2 Scale { get; set; }
    public MovementStrategy MovementStrategy { get; set; }
    public int Cost { get; set; }
    public float InitialHealth { get; set; }
    public float Health { get; set; }
    public int KillReward { get; set; }
    public float Damage { get; set; }
    public abstract LegionType Legion { get; }
}