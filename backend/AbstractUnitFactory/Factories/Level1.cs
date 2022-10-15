using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level1;
using tower_battle.Models;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes;
using tower_battle.AbstractUnitFactory.Builder;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class Level1 : AbstractUnitFactory
    {
        Director director = new Director();
        public override Unit CreateNormalMelee(bool isLeft)
        {
            Unit unit = new Level1NormalMelee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
            IBuilder builder = new NormalMeleeBuilder(unit);
            return director.ConstructLevel1(builder, new Normal());
        }
        public override Unit CreateFastMelee(bool isLeft)
        {
            Unit unit = new Level1FastMelee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
            IBuilder builder = new FastMeleeBuilder(unit);
            return this.director.ConstructLevel1(builder, new Fast());
        }
        public override Unit CreateSlowMelee(bool isLeft)
        {
            Unit unit = new Level1SlowMelee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
            IBuilder builder = new SlowMeleeBuilder(unit);
            return this.director.ConstructLevel1(builder, new Slow());
        }
    }
}
