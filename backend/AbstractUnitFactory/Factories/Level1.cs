using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level1;
using tower_battle.Models;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class Level1 : AbstractUnitFactory
    {
        public override Unit CreateNormalMelee(bool isLeft)
        {
            Unit unit = new Level1NormalMelee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
            unit.SetMoveStrategy(new Normal(),unit);
            return unit;
        }
        public override Unit CreateFastMelee(bool isLeft)
        {
            Unit unit = new Level1FastMelee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
            unit.SetMoveStrategy(new Fast(), unit);
            return unit;
        }
        public override Unit CreateSlowMelee(bool isLeft)
        {
            Unit unit = new Level1SlowMelee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
            unit.SetMoveStrategy(new Slow(), unit);
            return unit;
        }
    }
}
