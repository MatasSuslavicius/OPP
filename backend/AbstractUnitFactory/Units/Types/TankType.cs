using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.Types
{
    public class TankType : UnitType
    {
        public override string Name => "Tank";
        public override Vector2 Scale => new() { X = 1.5f, Y = 0.75f };
    }
}
