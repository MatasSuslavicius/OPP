using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.Types
{
    public class TankType : UnitType
    {
        public override string Name => "Tank";

        public override LegionType Legion => LegionType.Tank;
    }
}
