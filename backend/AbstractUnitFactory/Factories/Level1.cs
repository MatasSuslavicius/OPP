using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level1;
using tower_battle.Models;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes;
using tower_battle.AbstractUnitFactory.Builder;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class Level1 : AbstractUnitFactory
    {
        public override Unit CreateNormalMelee(bool isLeft)
        {
            Unit unit = new Level1NormalMelee { Position = isLeft ? new Vector2() { X = -10, Y = 0 } : new Vector2() { X = 10, Y = 0 } };
            IBuilder builder = new NormalMeleeBuilder(unit);
            unit = this.director.ConstructLevel1(builder, new Normal());
            /*
            Unit testUnit = unit.CopyShallow();
            System.Diagnostics.Debug.WriteLine(unit.GetHashCode());
            System.Diagnostics.Debug.WriteLine(testUnit.GetHashCode());
            System.Diagnostics.Debug.WriteLine(unit.Health.GetHashCode());
            System.Diagnostics.Debug.WriteLine(testUnit.Health.GetHashCode());

            Unit testDeepUnit = unit.CopyDeep();
            System.Diagnostics.Debug.WriteLine(unit.GetHashCode());
            System.Diagnostics.Debug.WriteLine(testDeepUnit.GetHashCode());
            System.Diagnostics.Debug.WriteLine(unit.Health.GetHashCode());
            System.Diagnostics.Debug.WriteLine(testDeepUnit.Health.GetHashCode());
            */
            return unit;
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
