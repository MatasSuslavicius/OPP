using tower_battle.AbstractUnitFactory.Units.MovementStrategies;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Units.Types
{
    public class ScoutType : UnitType
    {
        public override string Name => "Scout";
        public override Vector2 Scale => new () { X = 0.75f, Y = 1.25f };
    }
}
