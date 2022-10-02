using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level2;
using tower_battle.Models;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class Level2 : AbstractUnitFactory
    {
        public override Unit CreateMelee(bool isLeft)
        {
            return new Level2Melee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
        }

        public override Unit CreateFastMelee()
        {
            return new Level2FastMelee();
        }
    }
}
