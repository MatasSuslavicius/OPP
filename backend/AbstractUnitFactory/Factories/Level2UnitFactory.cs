using tower_battle.AbstractUnitFactory.Units;
using tower_battle.AbstractUnitFactory.Units.Level2;
using tower_battle.Models;
using tower_battle.AbstractUnitFactory.Units.MovementStrategy.MoveTypes;
using tower_battle.AbstractUnitFactory.Builder;

namespace tower_battle.AbstractUnitFactory.Factories
{
    public class Level2UnitFactory : AbstractUnitFactory
    {
        public Level2UnitFactory(PlayerType playerType): base(playerType) { }
        public override Unit CreateNormalMelee()
        {
            Unit unit = new Level2NormalMelee { Position = SpawnPosition, Type = "normal" };
            IBuilder builder = new NormalMeleeBuilder(unit);
            return this.Director.ConstructLevel2(builder, new Normal());
        }

        public override Unit CreateFastMelee()
        {
            Unit unit = new Level2FastMelee { Position = SpawnPosition, Type = "fast" };
            IBuilder builder = new FastMeleeBuilder(unit);
            return this.Director.ConstructLevel2(builder, new Fast());
        }
        public override Unit CreateSlowMelee()
        {
            Unit unit = new Level2SlowMelee { Position = SpawnPosition, Type = "slow" };
            IBuilder builder = new SlowMeleeBuilder(unit);
            return this.Director.ConstructLevel2(builder, new Slow());
        }
    }
}
