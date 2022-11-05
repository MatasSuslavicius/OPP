using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.Types
{
    public class SoldierType : UnitType
    {
        public override string Name => "Soldier";
        public override Vector2 Scale => new() { X = 1f, Y = 1f };
    }
}
