using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level2;
using tower_battle.Models;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes;
using tower_battle.AbstractUnitFactory.Builder;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class Level2 : AbstractUnitFactory
    {
        public override Unit CreateNormalMelee(bool isLeft)
        {
            Unit unit = new Level2NormalMelee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
            IBuilder builder = new NormalMeleeBuilder(unit);
            return this.director.ConstructLevel2(builder, new Normal());
        }

        public override Unit CreateFastMelee(bool isLeft)
        {
            Unit unit = new Level2FastMelee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
            IBuilder builder = new FastMeleeBuilder(unit);
            return this.director.ConstructLevel2(builder, new Fast());
        }
        public override Unit CreateSlowMelee(bool isLeft)
        {
            Unit unit = new Level2SlowMelee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
            IBuilder builder = new SlowMeleeBuilder(unit);
            return this.director.ConstructLevel2(builder, new Slow());
        }
    }
}
